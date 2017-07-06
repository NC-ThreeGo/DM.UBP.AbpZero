using Abp.AutoMapper;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Modules
{
    [AutoMapFrom(typeof(Module))]
    public class CreateModuleInput
    {
        //[NotNullExpression]
        [Display(Name = "ID")]
        public long? Id { get; set; }

        //[Required]
        [Display(Name = "上级ID")]
        public long? ParentId { get; set; }

        [Display(Name = "模块编码")]
        [Required]
        public string ModuleCode { get; set; }

        [Display(Name = "模块名称")]
        [Required]
        public string ModuleName { get; set; }

        [Display(Name = "Url")]
        public string Url { get; set; }

        [Display(Name = "图标")]
        public string Icon { get; set; }

        [Display(Name = "排序号")]
        public int Sort { get; set; }

        [Display(Name = "说明")]
        public string Remark { get; set; }

        [Display(Name = "状态")]
        public bool EnabledMark { get; set; }

        [Display(Name = "是否最后一项")]
        public bool IsLast { get; set; }

        /// <summary>
        /// 是否处于修改状态，如果Id有值则表示修改否则表示新增。
        /// </summary>
        public bool IsEditMode
        {
            get { return Id.HasValue; }
        }
    }
}