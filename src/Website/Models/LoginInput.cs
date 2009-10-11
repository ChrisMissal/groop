using Castle.Components.Validator;

namespace Groop.Website.Models
{
    public class LoginInput
    {
        [ValidateNonEmpty]
        public string Username { get; set; }

        [ValidateNonEmpty]
        public string Password { get; set; }
    }
}