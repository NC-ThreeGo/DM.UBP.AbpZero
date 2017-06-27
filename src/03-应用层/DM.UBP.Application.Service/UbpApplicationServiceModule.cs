using System.Reflection;
using Abp.Modules;
using DM.UBP.Domain.Service;
using Abp.AutoMapper;
using DM.UBP.Application.Dto;

namespace DM.UBP.Application.Service
{
    [DependsOn(typeof(UbpDomainServiceModule), typeof(UbpApplicationDtoModule))]
    public class UbpApplicationServiceModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
