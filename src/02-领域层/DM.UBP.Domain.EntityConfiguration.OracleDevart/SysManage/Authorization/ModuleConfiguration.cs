using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.SysManage.Authorization
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
