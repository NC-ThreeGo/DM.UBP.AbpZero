using Abp;
using DM.UBP.Domain.Entity.SysManage.Friendships;

namespace DM.UBP.Domain.Service.SysManage.Friendships
{
    public static class FriendshipExtensions
    {
        public static UserIdentifier ToUserIdentifier(this Friendship friendship)
        {
            return new UserIdentifier(friendship.TenantId, friendship.UserId);
        }

        public static UserIdentifier ToFriendIdentifier(this Friendship friendship)
        {
            return new UserIdentifier(friendship.FriendTenantId, friendship.FriendUserId);
        }
    }
}
