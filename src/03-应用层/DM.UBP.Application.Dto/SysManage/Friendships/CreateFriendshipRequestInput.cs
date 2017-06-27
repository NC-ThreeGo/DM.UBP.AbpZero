using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace DM.UBP.Application.Dto.SysManage.Friendships
{
    public class CreateFriendshipRequestInput
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        public int? TenantId { get; set; }
    }
}