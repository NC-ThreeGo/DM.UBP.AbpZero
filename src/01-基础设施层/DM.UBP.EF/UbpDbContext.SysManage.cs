using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.Data.Entity;

namespace DM.UBP.EF
{
    public partial class UbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...
        /// <summary>
        /// 模块
        /// </summary>
        public virtual IDbSet<Module> Modules { get; set; }
        public virtual IDbSet<ModuleOperate> ModuleOperates { get; set; }
        public virtual IDbSet<ModuleColumnFilter> ColumnFilters { get; set; }

    }
}
