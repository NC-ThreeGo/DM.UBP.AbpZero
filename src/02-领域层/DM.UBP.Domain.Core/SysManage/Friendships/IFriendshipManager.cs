using Abp;
using Abp.Domain.Services;
using DM.UBP.Domain.Entity.SysManage.Friendships;

namespace DM.UBP.Domain.Service.SysManage.Friendships
{
    public interface IFriendshipManager : IDomainService
    {
        void CreateFriendship(Friendship friendship);

        void UpdateFriendship(Friendship friendship);

        Friendship GetFriendshipOrNull(UserIdentifier user, UserIdentifier probableFriend);

        void BanFriend(UserIdentifier userIdentifier, UserIdentifier probableFriend);
        
        void AcceptFriendshipRequest(UserIdentifier userIdentifier, UserIdentifier probableFriend);
    }
}
