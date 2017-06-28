using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DM.UBP.Application.Dto.SysManage.Authorization.Users.Profile;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.Collections.Generic;

namespace DM.UBP.Web.Areas.Mpa.Models.Profile
{
    [AutoMapFrom(typeof (CurrentUserProfileEditDto))]
    public class MySettingsViewModel : CurrentUserProfileEditDto
    {
        public List<ComboboxItemDto> TimezoneItems { get; set; }

        public bool CanChangeUserName
        {
            get { return UserName != User.AdminUserName; }
        }

        public MySettingsViewModel(CurrentUserProfileEditDto currentUserProfileEditDto)
        {
            currentUserProfileEditDto.MapTo(this);
        }
    }
}