using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using DM.UBP.Domain.Entity;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Modules
{
    [AutoMapFrom(typeof(ModuleColumnFilter))]
    public class ModuleColumnFilterDto : FullAuditedEntityDto<long>
    {
        [Display(Name = "字段编码")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Required]
        public string ColumnCode { get; set; }

        [Display(Name = "字段名称")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Required]
        public string ColumnName { get; set; }

        [Display(Name = "所属模块")]
        [Required]
        public long ModuleId { get; set; }

        [Display(Name = "是否验证")]
        public bool IsValid { get; set; }

        [Display(Name = "排序号")]
        [Required]
        public int Sort { set; get; }

        /// <summary>
        /// 是否处于修改状态，如果Id有值则表示修改否则表示新增。
        /// </summary>
        public bool IsEditMode
        {
            get { return Id >= 0; }
        }
    }
}
