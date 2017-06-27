using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Friendships
{
    public class CreateFriendshipRequestByUserNameInput
    {
        [Required(AllowEmptyStrings = true)]
        public string TenancyName { get; set; }

        public string UserName { get; set; }
    }
}