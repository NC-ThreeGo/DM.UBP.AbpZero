using Abp.MultiTenancy;
using DM.UBP.Domain.Entity.BaseManage.Permission;

namespace DM.UBP.Domain.Entity.BaseManage.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}