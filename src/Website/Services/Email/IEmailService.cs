namespace CRIneta.Website.Services.Email
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string message);
    }
}