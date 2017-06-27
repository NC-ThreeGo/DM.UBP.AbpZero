using Abp.Auditing;
using Abp.Authorization;
using Abp.AutoMapper;
using DM.UBP.Application.Dto.SysManage.Sessions;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Sessions
{
    [AbpAuthorize]
    public class SessionAppService : UbpAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                User = (await GetCurrentUserAsync()).MapTo<UserLoginInfoDto>()
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
            }

            return output;
        }
    }
}