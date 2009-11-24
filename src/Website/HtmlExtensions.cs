using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Groop.Website.Helpers.Extensions;

namespace Groop.Website
{
    public static class HtmlExtensions
    {
        public static string ActionLink1<TController>(this HtmlHelper helper, Expression<Func<TController, object>> actionExpression, string linkText)
        {
            string controllerName = typeof(TController).GetControllerName();
            string actionName = actionExpression.GetActionName();

            return helper.ActionLink(linkText, actionName, controllerName, null,
                                     new { @class = "action-link " + linkText.ToLower() });
        }
    }
}