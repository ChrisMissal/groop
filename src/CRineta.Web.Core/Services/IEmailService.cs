using CRIneta.Web.Core.Domain;

namespace CRIneta.Web.Core.Services
{
    public interface IEmailService
    {
        void Send(IContactMessage contactMessage);
    }
}