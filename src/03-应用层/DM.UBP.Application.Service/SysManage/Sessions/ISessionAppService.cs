using Abp.Application.Services;
using DM.UBP.Application.Dto.SysManage.Sessions;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
