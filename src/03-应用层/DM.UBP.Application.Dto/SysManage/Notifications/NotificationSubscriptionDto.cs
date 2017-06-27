using System.ComponentModel.DataAnnotations;
using Abp.Notifications;

namespace DM.UBP.Application.Dto.SysManage.Notifications
{
    public class NotificationSubscriptionDto
    {
        [Required]
        [MaxLength(NotificationInfo.MaxNotificationNameLength)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }
    }
}