using DM.UBP.Application.Dto.SysManage.Authorization.Permissions;
using System.Collections.Generic;

namespace DM.UBP.Web.Areas.Mpa.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}