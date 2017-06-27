using Abp.Notifications;
using System;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.SysManage.Notification
{
    public class TenantNotificationConfiguration : EntityConfigurationBase<TenantNotificationInfo, Guid>
    {
        public TenantNotificationConfiguration()
        {
            Property(j => j.EntityTypeAssemblyQualifiedName)
                .HasColumnName("EntityTypeAssemblyQN");
            Property(j => j.Data)
                .HasMaxLength(4000);
        }
    }
}
