using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Modules
{
    [AutoMapFrom(typeof(Module))]
    public class ModuleListDto : FullAuditedEntityDto
    {
        public long? ParentId { get; set; }

        [Required]
        public string ModuleCode { get; set; }

        [Required]
        public string ModuleName { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public string Target { set; get; }

        public bool IsLast { get; set; }

        [Required]
        public int? Sort { get; set; }

        public bool EnabledMark { get; set; }

        public string Remark { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        //[Required]
        public MultiTenancySides MultiTenancySide { get; set; }
    }
}