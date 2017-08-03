using Abp.Application.Navigation;
using Abp.Localization;
using DM.UBP.Application.Dto.SysManage.Authorization.Modules;
using DM.UBP.Application.Service.SysManage.Authorization.Modules;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Domain.Service;
using DM.UBP.Domain.Service.SysManage.Authorization;
using DM.UBP.Web.Navigation;
using System.Collections.Generic;
using TG.UBP.Domain.Service.SysManage.Authorization.Modules;

namespace DM.UBP.Web.Areas.Mpa.Startup
{
    public class UbpNavigationProvider : NavigationProvider
    {
        public const string MenuName = "Ubp";

        private IModuleAppService _moduleAppService;

        public UbpNavigationProvider(IModuleAppService moduleAppService)
        {
            _moduleAppService = moduleAppService;
        }

        public override void SetNavigation(INavigationProviderContext context)
        {
            var menu = context.Manager.Menus[MenuName] = new MenuDefinition(MenuName, new FixedLocalizableString("Main Menu"));
            menu
                .AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Tenants,
                    L("Tenants"),
                    url: "Mpa/Tenants",
                    icon: "icon-globe"
                    //,requiredPermissionName: AppPermissions.Pages_Tenants
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Host.Editions,
                    L("Editions"),
                    url: "Mpa/Editions",
                    icon: "icon-grid"
                    //,requiredPermissionName: AppPermissions.Pages_Editions
                    )
                ).AddItem(new MenuItemDefinition(
                    PageNames.App.Tenant.Dashboard,
                    L("Dashboard"),
                    url: "Mpa/Dashboard",
                    icon: "icon-home"
                    //,requiredPermissionName: AppPermissions.Pages_Tenant_Dashboard
                    )
                );

            List<Module> rootModuleList = _moduleAppService.GetModulesForNav(null).Result;
            CreateRootMenuItem(menu, rootModuleList);
        }

        private void CreateRootMenuItem(MenuDefinition rootMenu, List<Module> rootModuleList)
        {
            foreach (Module module in rootModuleList)
            {
                //TODO：暂时将requiredPermissionName=null，等权限判断搞完后再赋值。PermissionName格式：M_模块ID
                var menuItem = new MenuItemDefinition(module.ModuleCode, L(module.ModuleCode), module.Icon,
                    module.Url, requiredPermissionName: "M_" + module.Id.ToString()); // module.Id.ToString());
                rootMenu.AddItem(menuItem);
                List<Module> childModuleList = _moduleAppService.GetModulesForNav(module.Id).Result;
                CreateMenuItem(menuItem, childModuleList);
            }
        }

        private void CreateMenuItem(MenuItemDefinition parentMenuItem, List<Module> moduleList)
        {
            foreach (Module module in moduleList)
            {
                var menuItem = new MenuItemDefinition(module.ModuleCode, L(module.ModuleCode), module.Icon,
                    module.Url, requiredPermissionName: "M_" + module.Id.ToString()); // module.Id.ToString());
                parentMenuItem.AddItem(menuItem);
                if (!module.IsLast)
                {
                    List<Module> childModuleList = _moduleAppService.GetModulesForNav(module.Id).Result;
                    CreateMenuItem(menuItem, childModuleList);
                }
            }
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, UbpConsts.LocalizationSourceName);
        }
    }
}