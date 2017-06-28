using DM.UBP.Application.Dto.SysManage.Sessions;
using System.Threading.Tasks;

namespace DM.UBP.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
