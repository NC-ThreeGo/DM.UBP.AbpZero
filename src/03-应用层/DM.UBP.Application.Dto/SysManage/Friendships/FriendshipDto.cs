using Abp.AutoMapper;
using DM.UBP.Domain.Entity.SysManage.Friendships;
using DM.UBP.Domain.Service.SysManage.Friendships.Cache;
using System;

namespace DM.UBP.Application.Dto.SysManage.Friendships
{
    [AutoMapFrom(typeof(FriendCacheItem), typeof(Friendship))]
    public class FriendDto
    {
        public long FriendUserId { get; set; }

        public int? FriendTenantId { get; set; }

        public string FriendUserName { get; set; }

        public string FriendTenancyName { get; set; }

        public Guid? FriendProfilePictureId { get; set; }

        public int UnreadMessageCount { get; set; }

        public bool IsOnline { get; set; }

        public FriendshipState State { get; set; }
    }
}
