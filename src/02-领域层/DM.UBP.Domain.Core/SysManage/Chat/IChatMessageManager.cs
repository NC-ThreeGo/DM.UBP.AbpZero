using System;
using Abp;
using Abp.Domain.Services;
using DM.UBP.Domain.Entity.SysManage.Chat;

namespace DM.UBP.Domain.Service.SysManage.Chat
{
    public interface IChatMessageManager : IDomainService
    {
        void SendMessage(UserIdentifier sender, UserIdentifier receiver, string message, string senderTenancyName, string senderUserName, Guid? senderProfilePictureId);

        long Save(ChatMessage message);

        int GetUnreadMessageCount(UserIdentifier userIdentifier, UserIdentifier sender);
    }
}
