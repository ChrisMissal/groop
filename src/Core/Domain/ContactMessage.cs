namespace Groop.Core.Domain
{
    public class ContactMessage : IContactMessage
    {
        private string email;
        private string message;
        private string name;
        private string subject;

        public ContactMessage(string email, string name, string subject, string message)
        {
            this.email = email;
            this.name = name;
            this.subject = subject;
            this.message = message;
        }

        public string Email
        {
            get { return email; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Subject
        {
            get { return subject; }
        }

        public string Message
        {
            get { return message; }
        }

        public ContactMessage SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public ContactMessage SetName(string name)
        {
            this.name = name;
            return this;
        }

        public ContactMessage SetSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public ContactMessage SetMessage(string message)
        {
            this.message = message;
            return this;
        }
    }
}