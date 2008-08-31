using CRIneta.Model.Domain;

namespace CRIneta.Model
{
    public interface IUserSession
    {
        Member GetLoggedInUser();
        bool IsAdministrator();
        void PushUserMessage(FlashMessage.MessageType messageType, string message);
        FlashMessage[] PopUserMessages();
    }
}