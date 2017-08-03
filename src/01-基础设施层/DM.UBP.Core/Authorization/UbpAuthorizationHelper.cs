using Abp;
using Abp.Application.Features;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Localization;
using Abp.Runtime.Session;
using DM.UBP.Core.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DM.UBP.Core.Authorization
{
    public class UbpAuthorizationHelper : IUbpAuthorizationHelper, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }
        public IPermissionChecker PermissionChecker { get; set; }
        public IFeatureChecker FeatureChecker { get; set; }
        public ILocalizationManager LocalizationManager { get; set; }

        private readonly IFeatureChecker _featureChecker;
        private readonly IAuthorizationConfiguration _authConfiguration;

        public UbpAuthorizationHelper(IFeatureChecker featureChecker, IAuthorizationConfiguration authConfiguration)
        {
            _featureChecker = featureChecker;
            _authConfiguration = authConfiguration;
            AbpSession = NullAbpSession.Instance;
            PermissionChecker = NullPermissionChecker.Instance;
            LocalizationManager = NullLocalizationManager.Instance;
        }

        public async Task AuthorizeAsync(IEnumerable<IUbpAuthorizeAttribute> authorizeAttributes)
        {
            if (!_authConfiguration.IsEnabled)
            {
                return;
            }

            if (!AbpSession.UserId.HasValue)
            {
                throw new AbpAuthorizationException(
                    LocalizationManager.GetString(AbpConsts.LocalizationSourceName, "CurrentUserDidNotLoginToTheApplication")
                    );
            }

            foreach (var authorizeAttribute in authorizeAttributes)
            {
                //await PermissionChecker.AuthorizeAsync(authorizeAttribute.RequireAllPermissions, authorizeAttribute.Permissions);
            }
        }

        public async Task AuthorizeAsync(MethodInfo methodInfo)
        {
            await CheckFeatures(methodInfo);
            await CheckPermissions(methodInfo);
        }

        private async Task CheckFeatures(MethodInfo methodInfo)
        {
            var featureAttributes =
                ReflectionHelper.GetAttributesOfMemberAndDeclaringType<RequiresFeatureAttribute>(
                    methodInfo
                    );

            if (featureAttributes.Count <= 0)
            {
                return;
            }

            foreach (var featureAttribute in featureAttributes)
            {
                await _featureChecker.CheckEnabledAsync(featureAttribute.RequiresAll, featureAttribute.Features);
            }
        }

        private async Task CheckPermissions(MethodInfo methodInfo)
        {
            if (!_authConfiguration.IsEnabled)
            {
                return;
            }

            if (AllowAnonymous(methodInfo))
            {
                return;
            }

            var authorizeAttributes =
                ReflectionHelper.GetAttributesOfMemberAndDeclaringType(
                    methodInfo
                ).OfType<IUbpAuthorizeAttribute>().ToArray();

            if (!authorizeAttributes.Any())
            {
                return;
            }

            await AuthorizeAsync(authorizeAttributes);
        }

        private static bool AllowAnonymous(MethodInfo methodInfo)
        {
            return ReflectionHelper.GetAttributesOfMemberAndDeclaringType(methodInfo)
                .OfType<IAbpAllowAnonymousAttribute>().Any();
        }
    }
}
