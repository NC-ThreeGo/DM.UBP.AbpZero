using Abp.Domain.Uow;
using Abp.EntityFramework;
using Abp.Modules;
using System.Reflection;
using DM.UBP.Core;
using DM.UBP.Core.Config;
using DM.UBP.Domain.Service;

namespace DM.UBP.EF
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(UbpCoreModule), typeof(UbpDomainServiceModule))]
    public class UbpEFModule : AbpModule
    {
        private static bool _databaseInitialized;

        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //Configuration.DefaultNameOrConnectionString = "default";

            //根据ubp配置，获取connectionStringName
            UbpConfig config = UbpConfig.Instance;
            Configuration.DefaultNameOrConnectionString = config.DbContextInitializerConfig.ConnectionStringName;
        }

        public override void Initialize()
        {
            //模板自带的代码，改为根据配置文件初始化数据库。
            //Database.SetInitializer<UbpDbContext>(null);

            //根据ubp配置，获取DbContextInitializer，并初始化
            UbpConfig config = UbpConfig.Instance;
            IDatabaseInitializer databaseInitializer = IocManager.Resolve<IDatabaseInitializer>();
            if (!_databaseInitialized && databaseInitializer != null)
            {
                databaseInitializer.Initialize(config.DbContextInitializerConfig);
                _databaseInitialized = true;
            }
        }
    }
}
