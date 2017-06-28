using Abp.Web.Mvc.Authorization;
using DM.UBP.Domain.Service.SysManage.Authorization;
using DM.UBP.Web.Controllers;
using System.Web.Mvc;

namespace DM.UBP.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : UbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}