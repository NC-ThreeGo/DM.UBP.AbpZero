using Abp.WebApi.Controllers;
using DM.UBP.Domain.Service;

namespace DM.UBP.WebApi
{
    public abstract class UbpApiControllerBase : AbpApiController
    {
        protected UbpApiControllerBase()
        {
            LocalizationSourceName = UbpConsts.LocalizationSourceName;
        }
    }
}