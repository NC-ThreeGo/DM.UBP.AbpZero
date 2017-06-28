using System.Web.Mvc;

namespace DM.UBP.Web.Controllers
{
    public class AboutController : UbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}