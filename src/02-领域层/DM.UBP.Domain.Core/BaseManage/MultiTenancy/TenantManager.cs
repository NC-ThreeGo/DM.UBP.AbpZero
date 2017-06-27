using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;

using TG.UBP.Domain.Core.BaseManage.Editions;
using TG.UBP.Domain.Entity.BaseManage.MultiTenancy;
using TG.UBP.Domain.Entity.BaseManage.Permission;

namespace TG.UBP.Domain.Core.BaseManage.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore
            ) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore
            )
        {
        }
    }
}