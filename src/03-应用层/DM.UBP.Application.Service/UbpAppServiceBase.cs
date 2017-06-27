using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using DM.UBP.Domain.Service;

namespace DM.UBP.Application.Service
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class UbpAppServiceBase : ApplicationService
    {
        //public TenantManager TenantManager { get; set; }

        //public UserManager UserManager { get; set; }

        protected UbpAppServiceBase()
        {
            LocalizationSourceName = UbpConsts.LocalizationSourceName;
        }

        //protected virtual Task<User> GetCurrentUserAsync()
        //{
        //    var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
        //    if (user == null)
        //    {
        //        throw new ApplicationException("There is no current user!");
        //    }

        //    return user;
        //}

        //protected virtual Task<Tenant> GetCurrentTenantAsync()
        //{
        //    return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        //}

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}