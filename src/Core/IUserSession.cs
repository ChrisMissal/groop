using Groop.Core.Domain;

namespace Groop.Core
{
    public interface IUserSession
    {
        Member GetLoggedInUser();
        bool IsAdministrator();
        void PushUserMessage(FlashMessage.MessageType messageType, string message);
        FlashMessage[] PopUserMessages();
    }
}