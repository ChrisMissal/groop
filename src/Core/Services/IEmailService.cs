using Groop.Core.Domain;

namespace Groop.Core.Services
{
    public interface IEmailService
    {
        void Send(IContactMessage contactMessage);
    }
}