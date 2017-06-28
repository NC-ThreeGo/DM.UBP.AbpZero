using System.Web.Mvc;
using Abp.Auditing;

namespace DM.UBP.Web.Controllers
{
    public class ErrorController : UbpControllerBase
    {
        [DisableAuditing]
        public ActionResult E404()
        {
            return View();
        }
    }
}