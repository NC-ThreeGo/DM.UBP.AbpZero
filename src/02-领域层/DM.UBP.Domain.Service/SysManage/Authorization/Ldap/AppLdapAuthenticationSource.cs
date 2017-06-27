using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;

namespace DM.UBP.Domain.Service.SysManage.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
