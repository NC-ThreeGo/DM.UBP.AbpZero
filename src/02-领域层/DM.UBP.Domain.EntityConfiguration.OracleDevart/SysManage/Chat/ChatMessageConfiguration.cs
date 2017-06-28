using DM.UBP.Domain.Entity.SysManage.Chat;
using DM.UBP.EF;
using System;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.SysManage.Chat
{
    public class ChatMessageConfiguration : EntityConfigurationBase<ChatMessage, long>
    {
        public ChatMessageConfiguration()
        {
            Property(j => j.Message)
                .HasMaxLength(4000);
        }
    }
}
