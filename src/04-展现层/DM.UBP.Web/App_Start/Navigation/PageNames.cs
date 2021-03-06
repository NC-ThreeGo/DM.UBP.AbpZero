namespace DM.UBP.Web.Navigation
{
    /// <summary>
    /// 定义菜单名称
    ///     后续增加别的模块菜单时，1、新建PageNames.XXX.cs（XXX-模块名），然后在这个cs里参照下面的代码定义该模块的菜单名。
    ///                             2、
    /// </summary>
    public static partial class PageNames
    {
        public static partial class App
        {
            public static class Common
            {
                public const string Administration = "Administration";
                public const string Roles = "Administration.Roles";
                public const string Users = "Administration.Users";
                public const string AuditLogs = "Administration.AuditLogs";
                public const string OrganizationUnits = "Administration.OrganizationUnits";
                public const string Languages = "Administration.Languages";
            }

            public static class Host
            {
                public const string Tenants = "Tenants";
                public const string Editions = "Editions";
                public const string Maintenance = "Administration.Maintenance";
                public const string Settings = "Administration.Settings.Host";
            }

            public static class Tenant
            {
                public const string Dashboard = "Dashboard.Tenant";
                public const string Settings = "Administration.Settings.Tenant";
            }
        }

        public static class Frontend
        {
            public const string Home = "Frontend.Home";
            public const string About = "Frontend.About";
        }
    }
}