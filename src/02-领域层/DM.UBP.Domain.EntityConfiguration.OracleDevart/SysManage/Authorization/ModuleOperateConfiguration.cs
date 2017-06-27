using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.SysManage.Authorization
{
    public class ModuleOperateConfiguration : EntityConfigurationBase<ModuleOperate, long>
    {
        public ModuleOperateConfiguration()
        {
            this.ToTable("BASE_MODULEOPERATES");
            this.Property(p => p.Id).HasColumnName("OPERATE_ID");
            this.Property(p => p.ModuleId).HasColumnName("MODULE_ID");
        }
    }
}
