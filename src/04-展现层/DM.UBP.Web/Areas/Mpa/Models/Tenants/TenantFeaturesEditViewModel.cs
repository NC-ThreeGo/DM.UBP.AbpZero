using Abp.AutoMapper;
using DM.UBP.Application.Dto.SysManage.MultiTenancy;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;
using DM.UBP.Web.Areas.Mpa.Models.Common;

namespace DM.UBP.Web.Areas.Mpa.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesForEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}