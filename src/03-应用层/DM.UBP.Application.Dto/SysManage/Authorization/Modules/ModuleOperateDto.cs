using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DM.UBP.Domain.Entity;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Modules
{
    [AutoMapFrom(typeof(ModuleOperate))]
    public class ModuleOperateDto : FullAuditedEntityDto<long>
    {
        [Display(Name = "操作码")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Required]
        public string OperateCode { get; set; }

        [Display(Name = "操作名称")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Required]
        public string OperateName { get; set; }

        [Display(Name = "所属模块")]
        [Required]
        public long ModuleId { get; set; }

        [Display(Name = "是否验证")]
        public bool IsValid { get; set; }

        [Display(Name = " 排序码")]
        [Required]
        public int Sort { set; get; }

        /// <summary>
        /// 导航地址
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength200)]
        [Display(Name = "导航地址")]
        public string Url { set; get; }

        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Display(Name = "图标")]
        public string Icon { set; get; }

        /// <summary>
        /// 是否处于修改状态，如果Id有值则表示修改否则表示新增。
        /// </summary>
        public bool IsEditMode
        {
            get { return Id >= 0; }
        }
    }
}
