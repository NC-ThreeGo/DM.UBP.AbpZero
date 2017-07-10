using Abp.Runtime.Caching;
using Abp.Web.Models;
using DM.UBP.Application.Dto.SysManage.Authorization.Modules;
using DM.UBP.Application.Service.SysManage.Authorization.Modules;
using DM.UBP.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DM.UBP.Web.Areas.SysManage.Controllers
{
    public class ModuleController : UbpControllerBaseWithModuleCode
    {
        private IModuleAppService _moduleAppService;

        public ModuleController(ICacheManager cacheManager, IModuleAppService moduleAppService)
            :base(cacheManager, moduleAppService)
        {
            _moduleAppService = moduleAppService;
        }

        // GET: SysManage/Module
        public ActionResult Index()
        {
            ViewBag.CurrentPageName = GetModuleCode();
            ViewBag.AllOptJs = GetAllOperatesJsScripForThisModule().Content;
            return View();
        }

        //ABP通过 AjaxResponse 对象来包装Actions的返回值。可以通过[DontWrapResult]来Enable/Disable包装
        [DontWrapResult]
        public async Task<JsonResult> GetAllModuleList()
        {
            List<ModuleListDto> list = await _moduleAppService.GetAllModules();
            return Json(list, JsonRequestBehavior.AllowGet);

            //var result = new List<object>();
            //result.Add(new { Id = 1, Name = "系统设置", Url = "", ParentId = "", Level1 = 1, IsLeaf = false, Sort = 0 });
            //result.Add(new { Id = 2, Name = "权限管理", Url = "", ParentId = "1", Level1 = 2, IsLeaf = false, Sort = 0 });
            //result.Add(new { Id = 3, Name = "菜单管理", Url = "/Systems/Menu/Index", ParentId = "2", Level1 = 3, IsLeaf = true, Sort = 0 });
            //result.Add(new { Id = 4, Name = "用户管理", Url = "/Systems/User/Index", ParentId = "2", Level1 = 3, IsLeaf = true, Sort = 1 });
            //result.Add(new { Id = 5, Name = "日志管理", Url = "", ParentId = "", Level1 = 1, IsLeaf = false, Sort = 1 });
            //result.Add(new { Id = 6, Name = "查询日志", Url = "/Systems/Log/Index", ParentId = "5", Level1 = 2, IsLeaf = true, Sort = 0 });
            //result.Add(new { Id = 7, Name = "订单管理", Url = "", ParentId = "", Level1 = 1, IsLeaf = false, Sort = 2 });
            //return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult CreateModal(long? parentId)
        {
            var viewModel = new CreateModuleInput()
            {
                ParentId = parentId,
                Icon = "fa fa-puzzle-piece",
                EnabledMark = true,
                Sort = 0,
                MultiTenancySide = Abp.MultiTenancy.MultiTenancySides.Host | Abp.MultiTenancy.MultiTenancySides.Tenant,
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> EditModal(long id)
        {
            var module = await _moduleAppService.GetModuleById(id);
            return PartialView("_CreateOrEditModal", module);
        }

        public PartialViewResult CreateModal_Operate(long ModuleId)
        {
            var viewModel = new ModuleOperateDto()
            {
                Id = -1,
                ModuleId = ModuleId,
                //Icon = "fa fa-puzzle-piece",
                Sort = 0
            };

            return PartialView("_CreateOrEditModal_Opt", viewModel);
        }

        public async Task<PartialViewResult> EditModal_Operate(long id)
        {
            var moduleOpt = await _moduleAppService.GetModuleOperateById(id);
            return PartialView("_CreateOrEditModal_Opt", moduleOpt);
        }

        public PartialViewResult CreateModal_ColumnFilter(long ModuleId)
        {
            var viewModel = new ModuleColumnFilterDto()
            {
                Id = -1,
                ModuleId = ModuleId,
                Sort = 0
            };

            return PartialView("_CreateOrEditModal_CF", viewModel);
        }

        public async Task<PartialViewResult> EditModal_ColumnFilter(long id)
        {
            var columnFilter = await _moduleAppService.GetColumnFilterById(id);
            return PartialView("_CreateOrEditModal_CF", columnFilter);
        }
    }
}