using Abp.Application.Services;
using DM.UBP.Application.Dto.SysManage.Configuration.Tenants;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
