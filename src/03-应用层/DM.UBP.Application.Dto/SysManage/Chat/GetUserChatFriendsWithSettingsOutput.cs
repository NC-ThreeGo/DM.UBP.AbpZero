using DM.UBP.Application.Dto.SysManage.Friendships;
using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;

namespace DM.UBP.Application.Dto.SysManage.Chat
{
    public class GetUserChatFriendsWithSettingsOutput
    {
        public DateTime ServerTime { get; set; }

        public List<FriendDto> Friends { get; set; }

        public GetUserChatFriendsWithSettingsOutput()
        {
            Friends = new EditableList<FriendDto>();
        }
    }
}