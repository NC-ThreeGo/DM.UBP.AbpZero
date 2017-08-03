using Abp;
using Abp.Authorization;
using DM.UBP.Application.Dto.SysManage.Tenants.Dashboard;
using DM.UBP.Domain.Service.SysManage.Authorization;
using System.Linq;

namespace DM.UBP.Application.Service.SysManage.Tenants.Dashboard
{
    //[AbpAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class TenantDashboardAppService : UbpAppServiceBase, ITenantDashboardAppService
    {
        public GetMemberActivityOutput GetMemberActivity()
        {
            //Generating some random data. We could get numbers from database...
            return new GetMemberActivityOutput
                   {
                       TotalMembers = Enumerable.Range(0, 13).Select(i => RandomHelper.GetRandom(15, 40)).ToList(),
                       NewMembers = Enumerable.Range(0, 13).Select(i => RandomHelper.GetRandom(3, 15)).ToList()
                   };
        }
    }
}