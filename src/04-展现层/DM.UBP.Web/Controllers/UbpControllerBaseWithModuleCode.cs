using Abp.IdentityFramework;
using Abp.Runtime.Caching;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using DM.UBP.Application.Dto.SysManage.Authorization.Modules;
using DM.UBP.Application.Service.SysManage.Authorization.Modules;
using DM.UBP.Domain.Service;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DM.UBP.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// Add your methods to this class common for all controllers.
    /// 控制器的基类(带模块信息—模块编码、当前模块所有操作码)
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
            var module = _cacheManager
                    .GetCache(this.GetType().ToString())
                    .Get("Module", () => GetModuleFromDb(actionUrl)) as ModuleListDto;
            return _cacheManager
                    .GetCache(this.GetType().ToString())
                    .Get("ModuleCode@" + actionUrl, () => module.ModuleCode) as string;
        }

        /// <summary>
        /// 获取当前模块的所有操作码
        /// </summary>
        /// <returns></returns>
        public ContentResult GetAllOperatesJsScripForThisModule()
        {
            var actionUrl = GetActionUrl();
            var module = _cacheManager
                    .GetCache(this.GetType().ToString())
                    .Get("Module", () => GetModuleFromDb(actionUrl)) as ModuleListDto;
            return _cacheManager
                    .GetCache(this.GetType().ToString())
                    .Get("ModuleAllOperates@" + actionUrl, () => GetAllOperatesJsScriptByModuleFromDb(module.Id)) as ContentResult;
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

        private ModuleListDto GetModuleFromDb(string actionUrl)
        {
            return _moduleAppService.GetModuleByUrl(actionUrl).Result;
        }

        /// <summary>
        /// 根据ActionUrl获取当前模块的所有操作码的js定义语句，以便View中的Js代码判断权限
        /// </summary>
        /// <param name="actionUrl"></param>
        /// <returns></returns>
        private ContentResult GetAllOperatesJsScriptByModuleFromDb(long moduleId)
        {
            var script = new StringBuilder();
            script.AppendLine("   var _optPerms = {");
            var allOperatesList = _moduleAppService.GetModuleOperatesByModuleId(moduleId).Result;
            foreach(ModuleOperateDto opt in allOperatesList)
            {
                script.AppendLine("        '" + opt.OperateCode + "': 'O_" + opt.Id.ToString() + "',");
            }
            script.AppendLine("    };");

            return Content(script.ToString(), "application/x-javascript", Encoding.UTF8);
        }
    }
}