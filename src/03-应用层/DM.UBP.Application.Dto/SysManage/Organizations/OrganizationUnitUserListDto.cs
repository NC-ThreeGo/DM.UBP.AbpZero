using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System;

namespace DM.UBP.Application.Dto.SysManage.Organizations
{
    [AutoMapFrom(typeof(User))]
    public class OrganizationUnitUserListDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public Guid? ProfilePictureId { get; set; }

        public DateTime AddedTime { get; set; }
    }
}