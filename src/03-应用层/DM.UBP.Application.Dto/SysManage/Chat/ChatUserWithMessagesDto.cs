using System.Collections.Generic;

namespace DM.UBP.Application.Dto.SysManage.Chat
{
    public class ChatUserWithMessagesDto : ChatUserDto
    {
        public List<ChatMessageDto> Messages { get; set; }
    }
}