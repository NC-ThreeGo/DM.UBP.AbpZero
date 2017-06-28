using Abp.Dependency;
using Abp.Runtime.Session;
using Abp.Web.Mvc.Views;
using DM.UBP.Domain.Service;

namespace DM.UBP.Web.Views
{
    public abstract class UbpWebViewPageBase : UbpWebViewPageBase<dynamic>
    {
       
    }

    public abstract class UbpWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public IAbpSession AbpSession { get; private set; }
        
        protected UbpWebViewPageBase()
        {
            AbpSession = IocManager.Instance.Resolve<IAbpSession>();
            LocalizationSourceName = UbpConsts.LocalizationSourceName;
        }
    }
}