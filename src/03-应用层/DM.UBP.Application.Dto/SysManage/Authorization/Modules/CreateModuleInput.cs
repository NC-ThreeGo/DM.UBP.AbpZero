using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System;
using System.Collections.Generic;
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

        [Display(Name = "支持多租户")]
        public bool IsMultiTenancyEnabled { get; set; }

        [Display(Name = "多租户模式")]
        //[Required]
        public MultiTenancySides MultiTenancySide
        {
            get
            {
                foreach(ComboboxItemDto item in MultiTenancySidesCombox)
                {
                    if (item.IsSelected)
                        return (MultiTenancySides)int.Parse(item.Value);
                }
                return MultiTenancySides.Host | MultiTenancySides.Tenant;
            }
            set
            {
                foreach (ComboboxItemDto item in MultiTenancySidesCombox)
                {
                    if ((MultiTenancySides)int.Parse(item.Value) == value)
                        item.IsSelected = true;
                }
            }
        }

        /// <summary>
        /// 是否处于修改状态，如果Id有值则表示修改否则表示新增。
        /// </summary>
        public bool IsEditMode
        {
            get { return Id.HasValue; }
        }


        /// <summary>
        /// 将枚举MultiTenancySides的值加载到Combox中，以便页面显示。
        /// </summary>
        public List<ComboboxItemDto> MultiTenancySidesCombox { get; set; }

        public CreateModuleInput()
        {
            MultiTenancySidesCombox = new List<ComboboxItemDto>();
            foreach (MultiTenancySides item in Enum.GetValues(typeof(MultiTenancySides)))
            {
                MultiTenancySidesCombox.Add(new ComboboxItemDto(((int)item).ToString(), item.ToString()));
            }
            //由于枚举MultiTenancySides是Flags，所以需要增加3-Both值，以表示选择两个值。
            MultiTenancySidesCombox.Add(new ComboboxItemDto("3", "Both"));
        }
    }
}