using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.UBP.Domain.Entity.BaseManage.Permission;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.BaseManage.Permission
{
    public class ModuleConfiguration : EntityConfigurationBase<Module, long>
    {
        public ModuleConfiguration()
        {
            this.ToTable("BASE_MODULES");
            this.Property(p => p.Id).HasColumnName("MODULE_ID");

            //this.HasMany(m => m.Children).WithOptional(n => n.Parent);
        }
    }
}
