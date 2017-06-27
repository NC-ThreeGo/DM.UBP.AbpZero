using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;
using System;

namespace DM.UBP.Application.Dto.SysManage.Sessions
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public string EditionDisplayName { get; set; }

        public Guid? LogoId { get; set; }

        public string LogoFileType { get; set; }

        public Guid? CustomCssId { get; set; }
    }
}