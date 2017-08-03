using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DM.UBP.Core.Authorization
{
    public interface IUbpAuthorizationHelper
    {
        Task AuthorizeAsync(IEnumerable<IUbpAuthorizeAttribute> authorizeAttributes);

        Task AuthorizeAsync(MethodInfo methodInfo);
    }
}
