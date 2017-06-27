using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Users
{
    public class LinkToUserInput 
    {
        public string TenancyName { get; set; }

        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}