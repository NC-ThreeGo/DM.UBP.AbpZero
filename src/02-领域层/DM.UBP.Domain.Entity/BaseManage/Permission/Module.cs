using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.UBP.Domain.Entity.BaseManage.Permission
{
    public class Module : FullAuditedEntity<long>, IMayHaveTenant
    {
        public virtual int? TenantId { get; set; }

        /// <summary>
        /// 父级主键
        /// 如果为Null，则表示根模块
        /// </summary>
        [Display(Name = "上级ID")]
        public long ParentId { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        [Display(Name = "编码")]
        [StringLength(StringMaxLengthConst.MaxStringLength20)]
        public string ModuleCode { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Display(Name = "名称")]
        public string ModuleName { set; get; }
        /// <summary>
        /// 图标
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Display(Name = "图标")]
        public string Icon { set; get; }
        /// <summary>
        /// 导航地址
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength200)]
        [Display(Name = "导航地址")]
        public string Url { set; get; }
        /// <summary>
        /// 导航目标
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        [Display(Name = "导航目标")]
        public string Target { set; get; }
        /// <summary>
        /// 是否最后一项
        /// </summary>
        [Display(Name = "是否最后一项")]
        public bool IsLast { set; get; }
        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = " 排序码")]
        public int? Sort { set; get; }
        /// <summary>
        /// 有效标志
        /// </summary>
        [Display(Name = "有效标志")]
        public bool EnabledMark { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(StringMaxLengthConst.MaxStringLength200)]
        [Display(Name = "备注")]
        public string Remark { set; get; }

        /// <summary>
        /// 父级模块
        /// 如果为Null，则表示根模块
        /// </summary>
        //[ForeignKey("ParentId")]
        //public virtual Module Parent { get; set; }

        /// <summary>
        /// 子模块.
        /// </summary>
        //public virtual ICollection<Module> Children { get; set; }
    }
}
