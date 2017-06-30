using Abp.Application.Navigation;
using Abp.Localization;
using DM.UBP.Application.Dto.SysManage.Sessions;
using System.Collections.Generic;

namespace DM.UBP.Web.Models.Layout
{
    public class HeaderViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        public LanguageInfo CurrentLanguage { get; set; }

        public UserMenu Menu { get; set; }

        public string CurrentPageName { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        public bool TenantRegistrationEnabled { get; set; }

        public string GetShownLoginName()
        {
            if (!IsMultiTenancyEnabled)
            {
                if (LoginInformations.User != null)
                    return LoginInformations.User.UserName;
                else
                    return null;
            }

            return LoginInformations.Tenant == null
                ? ".\\" + LoginInformations.User.UserName
                : LoginInformations.Tenant.TenancyName + "\\" + LoginInformations.User.UserName;
        }
    }
}