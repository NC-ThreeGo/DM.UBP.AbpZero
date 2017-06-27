using System.Threading.Tasks;
using Abp.Configuration;

namespace DM.UBP.Domain.Service.SysManage.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
