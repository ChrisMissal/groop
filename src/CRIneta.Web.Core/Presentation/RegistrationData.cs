using Castle.Components.Validator;

namespace CRIneta.Web.Core.Presentation
{
    public class RegistrationData
    {
        private readonly string name;
        private readonly string lastName;
        private readonly string username;
        private readonly string email;
        private readonly string password;
        private readonly string passwordConfirm;

        public RegistrationData(string name, string lastName, string username, string email, string password, string passwordConfirm)
        {
            this.name = name;
            this.lastName = lastName;
            this.username = username;
            this.email = email;
            this.password = password;
            this.passwordConfirm = passwordConfirm;
        }

        [ValidateNonEmpty("Please enter a first name")]
        public string Name
        {
            get { return name; }
        }

        [ValidateNonEmpty("Please enter a last name")]
        public string LastName
        {
            get { return lastName; }
        }

        [ValidateNonEmpty("Please enter a username")]
        public string Username
        {
            get { return username; }
        }

        [ValidateNonEmpty("Please enter an email address")]
        [ValidateEmail("Please enter a valid email")]
        public string Email
        {
            get { return email; }
        }

        [ValidateNonEmpty("Please enter a password")]
        [ValidateSameAs("PasswordConfirm")]
        public string Password
        {
            get { return password; }
        }

        public string PasswordConfirm
        {
            get { return passwordConfirm; }
        }
    }
}