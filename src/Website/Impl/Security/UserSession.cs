using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using Groop.Core;
using Groop.Core.Data;
using Groop.Core.Domain;
using Groop.Core.Security;

namespace Groop.Website.Impl.Security
{
    public class UserSession : IUserSession
    {
        private readonly IAuthenticator authenticator;
        private readonly IMemberRepository memberRepository;
        private readonly IHttpContextProvider httpContextProvider;

        public UserSession(IAuthenticator authenticator, IMemberRepository memberRepository, IHttpContextProvider httpContextProvider)
        {
            this.authenticator = authenticator;
            this.httpContextProvider = httpContextProvider;
            this.memberRepository = memberRepository;
        }

        /// <summary>
        /// Gets the logged in user.
        /// </summary>
        /// <returns></returns>
        public virtual Member GetLoggedInUser()
        {
            IIdentity identity = authenticator.GetActiveIdentity();
            if (!identity.IsAuthenticated)
            {
                return null;
            }

            return memberRepository.GetByUsername(identity.Name);    
        }

        /// <summary>
        /// Determines whether this instance is administrator.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is administrator; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAdministrator()
        {
            Member member = GetLoggedInUser();
            return member != null && member.IsAdministrator;
        }

        #region Private Members

        private void PushUserMessage(FlashMessage message)
        {
            ensureFlashMessagesInitialized();
            Stack<FlashMessage> flash = getFlash();
            flash.Push(message);
        }

        private FlashMessage PopMessage()
        {
            var flash = getFlash();
            if (flash.Count == 0)
            {
                return null;
            }

            return flash.Pop();
        }

        private Stack<FlashMessage> getFlash()
        {
            ensureFlashMessagesInitialized();
            HttpSessionStateBase session = httpContextProvider.GetHttpSession();
            return (Stack<FlashMessage>)session["flash"];
        }

        private void ensureFlashMessagesInitialized()
        {
            HttpSessionStateBase session = httpContextProvider.GetHttpSession();
            var flash = session["flash"] as Stack<FlashMessage>;
            if (flash == null)
            {
                session["flash"] = new Stack<FlashMessage>();
            }
        }

        #endregion

        /// <summary>
        /// Pushes the user message.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="message">The message.</param>
        public void PushUserMessage(FlashMessage.MessageType messageType, string message)
        {
            var flashMessage = new FlashMessage(messageType, message);
            PushUserMessage(flashMessage);
        }

        /// <summary>
        /// Pops the user messages.
        /// </summary>
        /// <returns></returns>
        public FlashMessage[] PopUserMessages()
        {
            var messages = new List<FlashMessage>();
            FlashMessage message = PopMessage();
            while (message != null)
            {
                messages.Add(message);
                message = PopMessage();
            }

            return messages.ToArray();
        }
    }
}