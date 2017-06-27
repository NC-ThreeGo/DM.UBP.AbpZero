namespace DM.UBP.Application.Dto.SysManage.Configuration.Host
{
    public class UserLockOutSettingsEditDto
    {
        public bool IsEnabled { get; set; }

        public int MaxFailedAccessAttemptsBeforeLockout { get; set; }

        public int DefaultAccountLockoutSeconds { get; set; }
    }
}