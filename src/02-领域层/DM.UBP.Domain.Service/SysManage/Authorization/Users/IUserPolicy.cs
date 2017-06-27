using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace DM.UBP.Domain.Service.SysManage.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
