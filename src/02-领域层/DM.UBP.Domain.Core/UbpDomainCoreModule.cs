using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;

using DM.UBP.Domain.Entity;

namespace DM.UBP.Domain.Service
{
    [DependsOn(typeof(AbpZeroCoreModule),
        typeof(UbpDomainEntityModule))]
    public class UbpDomainServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            //Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            //Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            //Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //Remove the following line to disable multi-tenancy.
            Configuration.MultiTenancy.IsEnabled = UbpConsts.MultiTenancyEnabled;

            //Add/remove localization sources here
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    UbpConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "DM.UBP.Domain.Service.Localization.Source"
                        )
                    )
                );

            //BaseManage.Permission.Roles.AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            //Configuration.Authorization.Providers.Add<UbpAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
