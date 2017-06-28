using Abp.Web.Mvc.Authorization;
using DM.UBP.Application.Service.SysManage.Caching;
using DM.UBP.Domain.Service.SysManage.Authorization;
using DM.UBP.Web.Areas.Mpa.Models.Maintenance;
using DM.UBP.Web.Controllers;
using System.Web.Mvc;

namespace DM.UBP.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Maintenance)]
    public class MaintenanceController : UbpControllerBase
    {
        private readonly ICachingAppService _cachingAppService;

        public MaintenanceController(ICachingAppService cachingAppService)
        {
            _cachingAppService = cachingAppService;
        }

        public ActionResult Index()
        {
            var model = new MaintenanceViewModel
            {
                Caches = _cachingAppService.GetAllCaches().Items
            };

            return View(model);
        }
    }
}