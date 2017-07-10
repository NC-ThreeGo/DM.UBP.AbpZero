using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;

using DM.UBP.Domain.Entity;
using Abp.Zero.Ldap;
using Abp.AutoMapper;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Domain.Service.SysManage.Features;
using DM.UBP.Domain.Service.SysManage.Configuration;
using DM.UBP.Domain.Service.SysManage.Notifications;
using DM.UBP.Domain.Service.SysManage.Authorization.Roles;
using DM.UBP.Domain.Service.SysManage.Debugging;
using Abp.Net.Mail;
using Abp.Dependency;
using DM.UBP.Domain.Service.SysManage.Friendships.Cache;
using System;
using DM.UBP.Domain.Service.SysManage.Chat;
using DM.UBP.Domain.Service.SysManage.Friendships;

namespace DM.UBP.Domain.Service
{
    [DependsOn(typeof(AbpZeroCoreModule),
        typeof(UbpDomainEntityModule),
        typeof(AbpZeroLdapModule), 
        typeof(AbpAutoMapperModule)
        )]
    public class UbpDomainServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

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

            //Adding feature providers
            Configuration.Features.Providers.Add<AppFeatureProvider>();

            //Adding setting providers
            Configuration.Settings.Providers.Add<AppSettingProvider>();

            //Adding notification providers
            Configuration.Notifications.Providers.Add<AppNotificationProvider>();

            //Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = UbpConsts.MultiTenancyEnabled;

            //Enable LDAP authentication (It can be enabled only if MultiTenancy is disabled!)
            //Configuration.Modules.ZeroLdap().Enable(typeof(AppLdapAuthenticationSource));

            //Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            if (DebugHelper.IsDebug)
            {
                //Disabling email sending in debug mode
                IocManager.Register<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
            }

            Configuration.Caching.Configure(FriendCacheItem.CacheName, cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromMinutes(30);
            });

            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void Initialize()
        {
            //IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.RegisterIfNot<IChatCommunicator, NullChatCommunicator>();
            IocManager.Resolve<ChatUserStateWatcher>().Initialize();
        }
    }
}
