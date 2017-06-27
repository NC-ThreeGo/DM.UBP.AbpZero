using Abp.Application.Services;
using DM.UBP.Application.Dto.SysManage.Configuration.Host;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
