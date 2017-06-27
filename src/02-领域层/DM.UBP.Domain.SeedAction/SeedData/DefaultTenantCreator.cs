using System.Data.Entity;
using System.Linq;
using DM.UBP.Domain.Entity.BaseManage.MultiTenancy;

namespace DM.UBP.Domain.SeedAction.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly DbContext _context;

        public DefaultTenantCreator(DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Set<Tenant>().FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Set<Tenant>().Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
