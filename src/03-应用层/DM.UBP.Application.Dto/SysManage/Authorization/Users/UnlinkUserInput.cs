using Abp;
using Abp.Application.Services.Dto;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Users
{
    public class UnlinkUserInput
    {
        public int? TenantId { get; set; }

        public long UserId { get; set; }

        public UserIdentifier ToUserIdentifier()
        {
            return new UserIdentifier(TenantId, UserId);
        }
    }
}