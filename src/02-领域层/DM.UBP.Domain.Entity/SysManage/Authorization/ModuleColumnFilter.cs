using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.UBP.Domain.Entity.SysManage.Authorization
{
    public class ModuleColumnFilter : FullAuditedEntity<long>
    {
        [Display(Name = "字段编码")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        public string ColumnCode { get; set; }

        [Display(Name = "字段名称")]
        [StringLength(StringMaxLengthConst.MaxStringLength50)]
        public string ColumnName { get; set; }

        [Display(Name = "所属模块")]
        public long ModuleId { get; set; }

        [Display(Name = "是否验证")]
        public bool IsValid { get; set; }

        [Display(Name = "排序号")]
        public int Sort { set; get; }

        //public virtual Module Model { get; set; }
    }
}
