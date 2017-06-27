using DM.UBP.Application.Dto.SysManage.Authorization.Permissions;
using System.Collections.Generic;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Users
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}