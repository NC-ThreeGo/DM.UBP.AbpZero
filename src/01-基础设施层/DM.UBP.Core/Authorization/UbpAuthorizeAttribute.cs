using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.UBP.Core.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class UbpAuthorizeAttribute : Attribute, IUbpAuthorizeAttribute
    {
        public UbpAuthorizeType AuthorizeType { get; set; }

        /// <summary>
        /// A list of permissions to authorize.
        /// </summary>
        public string[] OperateCodes { get; }

        /// <summary>
        /// If this property is set to true, all of the <see cref="Permissions"/> must be granted.
        /// If it's false, at least one of the <see cref="Permissions"/> must be granted.
        /// Default: false.
        /// </summary>
        public bool RequireAllPermissions { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="AbpAuthorizeAttribute"/> class.
        /// </summary>
        /// <param name="permissions">A list of permissions to authorize</param>
        public UbpAuthorizeAttribute(params string[] operateCodes)
        {
            OperateCodes = operateCodes;
        }
    }
}
