using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;

using TG.UBP.Domain.Entity.BaseManage.Permission;

namespace TG.UBP.Domain.Core.BaseManage.Permission.Roles
{
    public class RoleStore : AbpRoleStore<Role, User>
    {
        public RoleStore(
            IRepository<TG.UBP.Domain.Entity.BaseManage.Permission.Role> roleRepository,
            IRepository<UserRole, long> userRoleRepository,
            IRepository<RolePermissionSetting, long> rolePermissionSettingRepository)
            : base(
                roleRepository,
                userRoleRepository,
                rolePermissionSettingRepository)
        {
        }
    }
}