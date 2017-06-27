using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Friendships
{
    public class UnblockUserInput
    {
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }

        public int? TenantId { get; set; }
    }
}