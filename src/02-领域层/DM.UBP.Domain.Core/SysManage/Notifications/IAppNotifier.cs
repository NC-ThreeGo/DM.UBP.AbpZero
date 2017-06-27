using Abp;
using Abp.Notifications;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;
using System.Threading.Tasks;

namespace DM.UBP.Domain.Service.SysManage.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task NewUserRegisteredAsync(User user);

        Task NewTenantRegisteredAsync(Tenant tenant);

        Task SendMessageAsync(UserIdentifier user, string message, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
