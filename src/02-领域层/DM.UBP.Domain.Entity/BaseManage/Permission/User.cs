using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;

namespace DM.UBP.Domain.Entity.BaseManage.Permission
{
    /// <summary>
    /// 用户。
    ///     UserLogin—用户第三方登录（OAuth，如facebook,google）信息
    ///     UserClaim—用户摘要标识信息
    ///     UserRole—用户角色映射信息
    /// </summary>
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };
        }

        #region 重载属性
        //public override string Surname { get; set; }
        #endregion
    }
}