using Castle.Components.Validator;

namespace CRIneta.Web.Core.Presentation
{
    public class ContactMessageData
    {
        [ValidateEmail]
        public string Email { get; set; }

        [ValidateNonEmpty]
        public string Name { get; set; }

        [ValidateNonEmpty]
        public string Subject { get; set; }

        [ValidateNonEmpty]
        public string Message { get; set; }
    }
}