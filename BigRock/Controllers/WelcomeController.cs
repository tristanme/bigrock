using System.Web;
using System.Web.Mvc;

namespace BigRock.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: /Welcome/ 

        public ActionResult Index(string name, int numTimes = 1)
        {
            //return HttpUtility.HtmlEncode("Hello " + name + ", NumTimes is: " + numTimes);
            return View();
        }

    }
}