using Abp.Notifications;
using System;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.BaseManage.Notification
{
    public class NotificationSubscriptionConfiguration : EntityConfigurationBase<NotificationSubscriptionInfo, Guid>
    {
        public NotificationSubscriptionConfiguration()
        {
            Property(j => j.EntityTypeAssemblyQualifiedName)
                .HasColumnName("EntityTypeAssemblyQN");
        }
    }
}
