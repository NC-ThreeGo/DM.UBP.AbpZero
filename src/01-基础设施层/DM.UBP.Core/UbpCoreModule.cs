using Abp;
using Abp.Modules;
using System.Reflection;

namespace DM.UBP.Core
{
    [DependsOn(typeof(AbpKernelModule))]
    public class UbpCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());//这里，进行依赖注入的注册。
        }
    }
}
