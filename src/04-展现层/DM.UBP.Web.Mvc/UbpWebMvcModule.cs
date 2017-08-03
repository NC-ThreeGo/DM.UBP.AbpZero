using Abp.Modules;
using Abp.Web;
using Abp.Web.Mvc.Authorization;
using System.Reflection;
using System.Web.Mvc;

namespace DM.UBP.Web.Mvc
{
    /// <summary>
    /// This module is used to build ASP.NET MVC web sites using Abp.
    /// </summary>
    [DependsOn(typeof(AbpWebModule))]
    public class UbpWebMvcModule : AbpModule
    {
        /// <inheritdoc/>
        public override void PreInitialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            //在GlobalFilters中用UbpMvcAuthorizeFilter替换AbpMvcAuthorizeFilter。
            //  AbpMvcAuthorizeFilter使用固定权限名称进行验证，而UbpMvcAuthorizeFilter使用当前Url进行验证。
            //foreach (Filter filter in GlobalFilters.Filters)
            //{
            //    if (filter.Instance.GetType() == typeof(AbpMvcAuthorizeFilter))
            //    {
            //        GlobalFilters.Filters.Remove(filter.Instance);
            //        break;
            //    }
            //}
            //GlobalFilters.Filters.Add(IocManager.Resolve<UbpMvcAuthorizeFilter>());
        }
    }
}
