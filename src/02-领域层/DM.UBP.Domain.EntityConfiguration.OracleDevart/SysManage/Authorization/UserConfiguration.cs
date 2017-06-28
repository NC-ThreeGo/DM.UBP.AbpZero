using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.EF;

namespace DM.UBP.Domain.EntityConfiguration.OracleDevart.SysManage.Authorization
{
    public class UserConfiguration : EntityConfigurationBase<User, long>
    {
        public UserConfiguration()
        {
            Property(p => p.ShouldChangePasswordOnNextLogin).HasColumnName("ShouldChangePwdOnNextLogin");
        }
    }
}
