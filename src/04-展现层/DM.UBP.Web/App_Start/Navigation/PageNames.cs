namespace DM.UBP.Web.Navigation
{
    /// <summary>
    /// ����˵�����
    ///     �������ӱ��ģ��˵�ʱ��1���½�PageNames.XXX.cs��XXX-ģ��������Ȼ�������cs���������Ĵ��붨���ģ��Ĳ˵�����
    ///                             2��
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