using System.Web.Mvc;

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