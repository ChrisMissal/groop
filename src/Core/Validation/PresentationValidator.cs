using Castle.Components.Validator;

namespace Groop.Core.Validation
{
    public class PresentationValidator : ValidatorRunner, IValidator
    {
        public PresentationValidator(IValidatorRegistry registry) : base(registry)
        {
        }

        public PresentationValidator(bool inferValidators, IValidatorRegistry registry) : base(inferValidators, registry)
        {
        }

        public PresentationValidator() : base(new CachedValidationRegistry())
        {
        }

        public bool IsValid<T>(T type)
        {
            return base.IsValid(type);
        }
    }
}