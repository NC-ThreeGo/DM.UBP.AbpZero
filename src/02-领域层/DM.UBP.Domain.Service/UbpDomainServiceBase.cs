using Abp.Domain.Services;

namespace DM.UBP.Domain.Service
{
    public abstract class UbpDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected UbpDomainServiceBase()
        {
            LocalizationSourceName = UbpConsts.LocalizationSourceName;
        }
    }
}
