using Abp.AutoMapper;
using DM.UBP.Application.Dto.SysManage.Authorization.Users;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Web.Areas.Mpa.Models.Common;

namespace DM.UBP.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}