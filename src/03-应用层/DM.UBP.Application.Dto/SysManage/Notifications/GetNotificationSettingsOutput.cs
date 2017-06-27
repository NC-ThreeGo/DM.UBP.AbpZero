using System.Collections.Generic;

namespace DM.UBP.Application.Dto.SysManage.Notifications
{
    public class GetNotificationSettingsOutput
    {
        public bool ReceiveNotifications { get; set; }

        public List<NotificationSubscriptionWithDisplayNameDto> Notifications { get; set; }
    }
}