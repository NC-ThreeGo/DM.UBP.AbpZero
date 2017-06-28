using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using DM.UBP.Domain.Service.SysManage.Authorization;
using DM.UBP.Web.Controllers;
using System.Web.Mvc;

namespace DM.UBP.Web.Areas.Mpa.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : UbpControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}