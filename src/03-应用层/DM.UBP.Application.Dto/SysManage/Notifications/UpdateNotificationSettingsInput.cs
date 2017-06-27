using System.Collections.Generic;

namespace DM.UBP.Application.Dto.SysManage.Notifications
{
    public class UpdateNotificationSettingsInput
    {
        public bool ReceiveNotifications { get; set; }

        public List<NotificationSubscriptionDto> Notifications { get; set; }
    }
}