using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core
{
    public interface IUserSession
    {
        Member GetLoggedInUser();
        bool IsAdministrator();
        void PushUserMessage(FlashMessage.MessageType messageType, string message);
        FlashMessage[] PopUserMessages();
    }
}