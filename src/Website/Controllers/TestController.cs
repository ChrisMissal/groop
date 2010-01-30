using System.Web.Mvc;
using Groop.Core;
using Groop.Website.Helpers;

namespace Groop.Website.Controllers
{
    public class TestController : System.Web.Mvc.Controller
    {
        public ContentResult Test()
        {
            var sessionInfo = IoC.Resolve<IUserSession>();
            return new ContentResult()
                       {
                           Content = "Hello World" + sessionInfo.GetType()
                       };
        }
    }
}