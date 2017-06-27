using DM.UBP.Domain.Service.SysManage.Editions;
using DM.UBP.EF;
using System.Linq;

namespace DM.UBP.Domain.SeedAction.SeedData.Tenants
{
    public class DefaultTenantBuilder
    {
        private readonly UbpDbContext _context;

        public DefaultTenantBuilder(UbpDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultTenant();
        }

        private void CreateDefaultTenant()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Entity.SysManage.MultiTenancy.Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                defaultTenant = new Entity.SysManage.MultiTenancy.Tenant(Entity.SysManage.MultiTenancy.Tenant.DefaultTenantName, Entity.SysManage.MultiTenancy.Tenant.DefaultTenantName);

                var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
                if (defaultEdition != null)
                {
                    defaultTenant.EditionId = defaultEdition.Id;
                }

                _context.Tenants.Add(defaultTenant);
                _context.SaveChanges();
            }
        }
    }
}
