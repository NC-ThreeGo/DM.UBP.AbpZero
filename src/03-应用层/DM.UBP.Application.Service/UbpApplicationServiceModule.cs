using System.Reflection;
using Abp.Modules;
using DM.UBP.Domain.Service;
using Abp.AutoMapper;
using DM.UBP.Application.Dto;
using DM.UBP.Domain.Service.SysManage.Authorization;

namespace DM.UBP.Application.Service
{
    [DependsOn(typeof(UbpDomainServiceModule), typeof(UbpApplicationDtoModule))]
    public class UbpApplicationServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            //Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //注册Ubp Authorization Providers
            Configuration.Authorization.Providers.Add<UbpAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                CustomDtoMapper.CreateMappings(mapper);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
