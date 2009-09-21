using Castle.Components.Validator;

namespace CRIneta.Web.Core.Presentation
{
    public class RegistrationData
    {
        [ValidateNonEmpty("Please enter a first name")]
        public string FirstName { get; set; }

        [ValidateNonEmpty("Please enter a last name")]
        public string LastName { get; set; }

        [ValidateNonEmpty("Please enter a username")]
        public string UserName { get; set; }

        [ValidateNonEmpty("Please enter an email address")]
        [ValidateEmail("Please enter a valid email")]
        public string Email { get; set; }

        [ValidateNonEmpty("Please enter a password")]
        [ValidateSameAs("PasswordConfirm")]
        public string Password { get; set; }

        public string PasswordConfirm { get; set; }
    }
}