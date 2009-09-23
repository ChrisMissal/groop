using System.Web.Mvc;
using CRIneta.Web.Core;

namespace CRIneta.Website.Controllers
{
    public class TestController : System.Web.Mvc.Controller
    {
        public ContentResult Test()
        {
            return new ContentResult()
                       {
                           Content = "Hello World"
                       };
        }
    }
}