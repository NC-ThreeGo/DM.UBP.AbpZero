using DM.UBP.Application.Dto.SysManage.Authorization.Users;
using System.Collections.Generic;

namespace DM.UBP.Web.Areas.Mpa.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}