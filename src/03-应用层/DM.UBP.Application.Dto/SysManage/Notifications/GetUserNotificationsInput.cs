using Abp.Notifications;
using DM.UBP.Application.Dto.Common;

namespace DM.UBP.Application.Dto.SysManage.Notifications
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}