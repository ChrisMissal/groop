using System.Net.Mail;
using Groop.Core.Domain;
using Groop.Core.Services;

namespace Groop.Website.Services.Email
{
    public class FakeEmailService : IEmailService
    {
        public void Send(IContactMessage contactMessage)
        {
            return;
        }
    }

    public class SmtpEmailService : IEmailService
    {
        private readonly string host;
        private readonly int port;
        private string defaultFrom;
        private SmtpClient smtpClient;
        private readonly string defaultTo;

        public SmtpEmailService(string host, int port, string defaultFrom, string defaultTo)
        {
            this.host = host;
            this.defaultTo = defaultTo;
            this.port = port;
            this.defaultFrom = defaultFrom;
        }

        /// <summary>
        /// Gets the SMTP client.
        /// </summary>
        /// <value>The SMTP client.</value>
        private SmtpClient SmtpClient
        {
            get
            {
                if (smtpClient == null)
                {
                    smtpClient = new SmtpClient(host, port);
                }

                return smtpClient;
            }
        }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>From.</value>
        public virtual string From
        {
            get { return defaultFrom; }
            set { defaultFrom = value; }
        }

        #region IEmailService Members

        /// <summary>
        /// Composes and sends and email with the properties specified
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="from">From.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        public virtual void Send(string to, string from, string subject, string body)
        {
            var message = new MailMessage(from, to, subject, body);
            message.IsBodyHtml = true;

            SmtpClient.Send(message);
        }

        #endregion

        /// <summary>
        /// Composes and sends and email with the properties specified using the default "from"
        /// </summary>
        /// <param name="message">The message.</param>
        public virtual void Send(IContactMessage message)
        {
            Send(defaultTo, message.Email, message.Subject, message.Message);
        }
    }
}