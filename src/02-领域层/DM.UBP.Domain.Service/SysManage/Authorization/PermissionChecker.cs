using System.Threading.Tasks;
using Abp.Authorization;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;
using DM.UBP.Domain.Service.SysManage.Authorization.Users;
using Abp.Threading;
using Abp;

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

        //TODO：需要修改成通过数据库判断是否有权限。
        //public override async Task<bool> IsGrantedAsync(string permissionName)
        //{
        //    return true;
        //}

        //public override async Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        //{
        //    return true;
        //}
    }
}
