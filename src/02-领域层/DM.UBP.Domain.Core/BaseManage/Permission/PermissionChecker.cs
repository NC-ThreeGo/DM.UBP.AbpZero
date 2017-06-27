using Abp.Authorization;

using TG.UBP.Domain.Core.BaseManage.Permission.Users;
using TG.UBP.Domain.Entity.BaseManage.Permission;

namespace TG.UBP.Domain.Core.BaseManage.Permission
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
