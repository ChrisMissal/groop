using System;
using System.Web.Mvc;
using Castle.Components.Validator;

namespace Groop.Website.Helpers.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly Type viewModelType;
        private readonly IValidatorRunner validatorRunner;

        public ValidateModelAttribute(Type viewModelType, IValidatorRunner validatorRunner)
        {
            this.viewModelType = viewModelType;
            this.validatorRunner = validatorRunner;
        }

        public ValidateModelAttribute(Type viewModelType) : this(viewModelType, IoC.Resolve<IValidatorRunner>())
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object model = GetModelFromActionParameters(filterContext);

            if (!validatorRunner.IsValid(model))
            {
                AddErrorsToModelState(filterContext, model);
            }
        }

        private object GetModelFromActionParameters(ActionExecutingContext filterContext)
        {
            foreach (var kvp in filterContext.ActionParameters)
            {
                if (kvp.Value == null)
                {
                    continue;
                }

                if (kvp.Value.GetType() == viewModelType)
                {
                    return kvp.Value;
                }
            }

            throw new NullReferenceException("The action parameter was null.  Check the binding prefix.");
        }

        private void AddErrorsToModelState(ControllerContext context, object model)
        {
            ErrorSummary summary = validatorRunner.GetErrorSummary(model);
            foreach (string property in summary.InvalidProperties)
            {
                string[] errorsForProperty = summary.GetErrorsForProperty(property);
                string errors = FlattenErrors(errorsForProperty);
                context.Controller.ViewData.ModelState.AddModelError(property, errors);
            }
        }

        // todo refactor
        private static string FlattenErrors(string[] errorsForProperty)
        {
            return string.Join(", ", errorsForProperty);
        }
    }
}