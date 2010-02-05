using System.Web.Mvc;

namespace Groop.Website.Helpers.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string Text(this HtmlHelper @this, string output)
        {
            return (output ?? "").Replace("\n", "<br />");
        }
    }
}