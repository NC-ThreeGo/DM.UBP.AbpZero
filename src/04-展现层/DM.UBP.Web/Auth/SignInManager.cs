using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Uow;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using DM.UBP.Domain.Entity.SysManage.MultiTenancy;
using DM.UBP.Domain.Service.SysManage.Authorization.Users;
using Microsoft.Owin.Security;

namespace DM.UBP.Web.Auth
{
    public class SignInManager : AbpSignInManager<Tenant, Role, User>
    {
        public SignInManager(
            UserManager userManager, 
            IAuthenticationManager authenticationManager, 
            ISettingManager settingManager,
            IUnitOfWorkManager unitOfWorkManager) 
            : base(
                  userManager, 
                  authenticationManager,
                  settingManager,
                  unitOfWorkManager)
        {
        }
    }
}