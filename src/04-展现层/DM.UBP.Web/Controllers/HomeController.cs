using System.Web.Mvc;

namespace DM.UBP.Web.Controllers
{
    public class HomeController : UbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}