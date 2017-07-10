using Abp.IdentityFramework;
using Abp.Runtime.Caching;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using DM.UBP.Application.Service.SysManage.Authorization.Modules;
using DM.UBP.Domain.Service;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace DM.UBP.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// Add your methods to this class common for all controllers.
    /// </summary>
    public abstract class UbpControllerBase : AbpController
    {
        protected UbpControllerBase()
        {
            LocalizationSourceName = UbpConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}