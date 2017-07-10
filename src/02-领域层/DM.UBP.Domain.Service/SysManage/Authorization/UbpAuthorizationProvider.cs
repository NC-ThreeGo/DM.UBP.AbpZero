using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Localization;
using Abp.MultiTenancy;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.Collections.Generic;
using System.Linq;
using TG.UBP.Domain.Service.SysManage.Authorization.Modules;

namespace DM.UBP.Domain.Service.SysManage.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class UbpAuthorizationProvider : AuthorizationProvider
    {
        public const string _rootPermission = "Ubp";

        private readonly bool _isMultiTenancyEnabled;

        private IModuleManager _moduleManager;


        public UbpAuthorizationProvider(bool isMultiTenancyEnabled
            //,IModuleManagers moduleManagers
            )
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
            //_moduleManagers = moduleManagers;
        }

        public UbpAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        [UnitOfWork]
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            if (_moduleManager == null)
            {
                _moduleManager = IocManager.Instance.Resolve<ModuleManager>();
            }

            var rootPermission = context.GetPermissionOrNull(_rootPermission) ?? context.CreatePermission(_rootPermission, L(_rootPermission));
            rootPermission.CreateChildPermission("Dashboard", L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);
            List<Module> childModuleList = _moduleManager.GetModulesAsync(null).Result;
            CreateChildPermission(rootPermission, childModuleList);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, UbpConsts.LocalizationSourceName);
        }

        private void CreateChildPermission(Permission permission, List<Module> moduleList)
        {
            foreach (Module module in moduleList)
            {
                var perm = permission.CreateChildPermission(module.Id.ToString() + "_" + module.ModuleCode, L(module.ModuleCode));
                if (!module.IsLast)
                {
                    List<Module> childModuleList = _moduleManager.GetModulesAsync(module.Id).Result;
                    CreateChildPermission(perm, childModuleList);
                }
                else  //如果是末级模块（菜单），则加载模块操作权限
                {
                    List<ModuleOperate> moduleOperateList = _moduleManager.GetModuleOperatesAsync(module.Id).Result;
                    foreach(ModuleOperate opt in moduleOperateList)
                    {
                        perm.CreateChildPermission(opt.Id.ToString() + "_" + module.ModuleCode + "." + opt.OperateCode, L(opt.OperateCode));
                    }
                }
            }
        }
    }
}
