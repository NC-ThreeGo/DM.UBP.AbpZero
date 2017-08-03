using Abp.Authorization;
using Abp.Events.Bus;
using Abp.Logging;
using Abp.Web.Models;
using Abp.Web.Mvc.Authorization;
using Abp.Web.Mvc.Extensions;
using System.Web.Mvc;
using Abp.Reflection;

namespace DM.UBP.Web.Mvc
{
    /// <summary>
    /// 权限验证过滤器，继承于AbpMvcAuthorizeFilter。
    ///     AbpMvcAuthorizeFilter使用AppPermissions.Pages_XXX 常量进行验证，
    ///     UbpMvcAuthorizeFilter重载OnAuthorization方法，根据当前Url进行验证。
    /// </summary>
    public class UbpMvcAuthorizeFilter : AbpMvcAuthorizeFilter
    {
        public UbpMvcAuthorizeFilter(
            IAuthorizationHelper authorizationHelper,
            IErrorInfoBuilder errorInfoBuilder,
            IEventBus eventBus)
            : base(authorizationHelper, errorInfoBuilder, eventBus)
        {
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var actionUrl = GetActionUrl(filterContext);

            base.OnAuthorization(filterContext);

            //if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
            //    filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            //{
            //    return;
            //}

            //var methodInfo = filterContext.ActionDescriptor.GetMethodInfoOrNull();
            //if (methodInfo == null)
            //{
            //    return;
            //}

            //try
            //{
            //    //_authorizationHelper.Authorize(methodInfo);

            //    var authorizeAttributes =
            //        ReflectionHelper.GetAttributesOfMemberAndDeclaringType(
            //            methodInfo
            //        ).OfType<IAbpAuthorizeAttribute>().ToArray();

            //}
            //catch (AbpAuthorizationException ex)
            //{
            //    LogHelper.Logger.Warn(ex.ToString(), ex);
            //    HandleUnauthorizedRequest(filterContext, methodInfo, ex);
            //}
        }

        private string GetActionUrl(AuthorizationContext filterContext)
        {
            var urlInfo = ((System.Web.Routing.Route)filterContext.RouteData.Route.GetRouteData(filterContext.HttpContext).Route).Url.Split('/');
            string area;
            if (urlInfo[0] == "{controller}")
            {
                area = "";
            }
            else
            {
                area = urlInfo[0];
            }

            object controller, action;
            filterContext.RouteData.Route.GetRouteData(filterContext.HttpContext).Values.TryGetValue("controller", out controller);
            filterContext.RouteData.Route.GetRouteData(filterContext.HttpContext).Values.TryGetValue("action", out action);

            return string.IsNullOrEmpty(area) ? controller.ToString() + "/" + action.ToString()
                : area + "/" + controller.ToString() + "/" + action.ToString();
        }
    }
}
