using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Notifications;
using System;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Notifications
{
    public interface INotificationAppService : IApplicationService
    {
        Task<GetNotificationsOutput> GetUserNotifications(GetUserNotificationsInput input);

        Task SetAllNotificationsAsRead();

        Task SetNotificationAsRead(EntityDto<Guid> input);

        Task<GetNotificationSettingsOutput> GetNotificationSettings();
        
        Task UpdateNotificationSettings(UpdateNotificationSettingsInput input);
    }
}