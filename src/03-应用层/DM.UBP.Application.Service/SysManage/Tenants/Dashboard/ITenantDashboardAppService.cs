using Abp.Application.Services;
using DM.UBP.Application.Dto.SysManage.Tenants.Dashboard;

namespace DM.UBP.Application.Service.SysManage.Tenants.Dashboard
{
    public interface ITenantDashboardAppService : IApplicationService
    {
        GetMemberActivityOutput GetMemberActivity();
    }
}
