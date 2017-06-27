using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using DM.UBP.Domain.Entity.SysManage.Authorization;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Roles
{
    [AutoMap(typeof(Role))]
    public class RoleEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }
        
        public bool IsDefault { get; set; }
    }
}