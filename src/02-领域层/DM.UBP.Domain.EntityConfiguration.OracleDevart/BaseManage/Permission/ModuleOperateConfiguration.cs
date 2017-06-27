using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.UBP.Domain.Entity.BaseManage.Permission;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.BaseManage.Permission
{
    public class ModuleOperateConfiguration : EntityConfigurationBase<ModuleOperate, int>
    {
        public ModuleOperateConfiguration()
        {
            this.ToTable("BASE_MODULEOPERATES");
            this.Property(p => p.Id).HasColumnName("OPERATE_ID");
            this.Property(p => p.ModuleId).HasColumnName("MODULE_ID");
        }
    }
}
