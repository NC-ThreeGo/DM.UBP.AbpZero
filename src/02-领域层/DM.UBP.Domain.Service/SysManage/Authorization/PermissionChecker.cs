using Abp.Authorization;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;
using DM.UBP.Domain.Service.SysManage.Authorization.Users;

namespace DM.UBP.Domain.Service.SysManage.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
