namespace DM.UBP.Application.Dto.SysManage.Configuration.Host
{
    public class TwoFactorLoginSettingsEditDto
    {
        public bool IsEnabledForApplication { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsEmailProviderEnabled { get; set; }

        public bool IsSmsProviderEnabled { get; set; }

        public bool IsRememberBrowserEnabled { get; set; }
    }
}