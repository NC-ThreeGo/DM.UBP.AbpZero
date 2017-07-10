using Abp.IdentityFramework;
using Abp.Runtime.Caching;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using DM.UBP.Application.Service.SysManage.Authorization.Modules;
using DM.UBP.Domain.Service;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace DM.UBP.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// Add your methods to this class common for all controllers.
    /// </summary>
    public abstract class UbpControllerBaseWithModuleCode : UbpControllerBase
    {
        private readonly ICacheManager _cacheManager;
        private IModuleAppService _moduleAppService;

        protected UbpControllerBaseWithModuleCode(ICacheManager cacheManager, IModuleAppService moduleAppService)
        {
            LocalizationSourceName = UbpConsts.LocalizationSourceName;
            _cacheManager = cacheManager;
            _moduleAppService = moduleAppService;
        }

        public string GetModuleCode()
        {
            //从缓存中获取
            var actionUrl = GetActionUrl();
            return _cacheManager
                    .GetCache(this.GetType().ToString())
                    .Get(actionUrl, () => GetModuleCodeFromDb(actionUrl)) as string;
        }

        public string GetActionUrl()
        {
            var urlInfo = ((System.Web.Routing.Route)RouteData.Route.GetRouteData(this.HttpContext).Route).Url.Split('/');
            string area;
            if (urlInfo[0] == "{controller}")
            {
                area = "";
            }
            else
            {
                area = urlInfo[0];
            }

            object controller, action;
            RouteData.Route.GetRouteData(this.HttpContext).Values.TryGetValue("controller", out controller);
            RouteData.Route.GetRouteData(this.HttpContext).Values.TryGetValue("action", out action);

            return string.IsNullOrEmpty(area) ? controller.ToString() + "/" + action.ToString()
                : area + "/" + controller.ToString() + "/" + action.ToString();
        }

        private string GetModuleCodeFromDb(string actionUrl)
        {
            return _moduleAppService.GetModuleCodeByUrl(actionUrl).Result;
        }
    }
}