using DM.UBP.EF.Migrations;
using System.Data.Entity;

namespace DM.UBP.Domain.SeedAction
{
    public class CreateDatabaseSeedAction : ISeedAction
    {
        #region Implementation of ISeedAction

        /// <summary>
        /// 获取 操作排序，数值越小越先执行
        /// </summary>
        public int Order { get { return 1; } }

        /// <summary>
        /// 定义种子数据初始化过程
        /// </summary>
        /// <param name="context">数据上下文</param>
        public void Action(DbContext context)
        {
            //context.Set<Role>().Add(new Role() { Name = "系统管理员", Remark = "系统管理员角色，拥有系统最高权限", IsAdmin = true, IsSystem = true, CreatedTime = DateTime.Now });
            //context.Set<User>().Add(new User()
            //{
            //    UserName = "admin",
            //    NickName = "系统管理员",
            //    Email = "admin@threego.com",
            //    EmailConfirmed = false,
            //    PasswordHash = "AFJuxDmNkeA5Rg+djBwaDDhJFCEPC5fts9HtkV2zsu5q9L9OfPQ3sLmbIKJpGNlPCQ==",
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnabled = true
            //});


            //Host seed
            //new InitialHostDbBuilder(context).Create();

            //Default tenant seed (in host database).
            //new DefaultTenantCreator(context).Create();
            //new TenantRoleAndUserBuilder(context, 1).Create();
        }

        #endregion
    }
}