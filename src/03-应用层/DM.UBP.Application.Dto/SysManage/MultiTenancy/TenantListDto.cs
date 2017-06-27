using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;

namespace DM.UBP.Application.Dto.SysManage.MultiTenancy
{
    [AutoMapFrom(typeof (Tenant))]
    public class TenantListDto : EntityDto, IPassivable, IHasCreationTime
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }

        public string EditionDisplayName { get; set; }

        public string ConnectionString { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }
    }
}