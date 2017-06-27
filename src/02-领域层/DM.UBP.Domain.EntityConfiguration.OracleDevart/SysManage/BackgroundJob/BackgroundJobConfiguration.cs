using Abp.BackgroundJobs;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.SysManage.BackgroundJob
{
    public class BackgroundJobConfiguration : EntityConfigurationBase<BackgroundJobInfo, long>
    {
        public BackgroundJobConfiguration()
        {
            Property(j => j.JobArgs)
                .HasMaxLength(4000);
        }
    }
}
