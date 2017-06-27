using Abp.AutoMapper;
using Abp.Notifications;

namespace DM.UBP.Application.Dto.SysManage.Notifications
{
    [AutoMapFrom(typeof(NotificationDefinition))]
    public class NotificationSubscriptionWithDisplayNameDto : NotificationSubscriptionDto
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}