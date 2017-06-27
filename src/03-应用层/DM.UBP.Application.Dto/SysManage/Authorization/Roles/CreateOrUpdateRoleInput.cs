using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Roles
{
    public class CreateOrUpdateRoleInput 
    {
        [Required]
        public RoleEditDto Role { get; set; }

        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}