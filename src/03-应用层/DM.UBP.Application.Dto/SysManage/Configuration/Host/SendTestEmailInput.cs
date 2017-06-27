using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Configuration.Host
{
    public class SendTestEmailInput
    {
        [Required]
        [MaxLength(User.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}