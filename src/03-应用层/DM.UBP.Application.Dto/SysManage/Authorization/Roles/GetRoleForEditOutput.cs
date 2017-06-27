using DM.UBP.Application.Dto.SysManage.Authorization.Permissions;
using System.Collections.Generic;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Roles
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}