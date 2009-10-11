using Castle.Components.Validator;

namespace Groop.Website.Impl.UserInput
{
    public class LoginData
    {
        private readonly string username;
        private readonly string password;

        public LoginData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [ValidateNonEmpty("Please enter a username")]
        public string Username
        {
            get { return username; }
        }

        [ValidateNonEmpty("Please enter a password")]
        public string Password
        {
            get { return password; }
        }
    }
}