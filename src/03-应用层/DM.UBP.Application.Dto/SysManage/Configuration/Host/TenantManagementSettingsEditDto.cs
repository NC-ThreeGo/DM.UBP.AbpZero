namespace DM.UBP.Application.Dto.SysManage.Configuration.Host
{
    public class TenantManagementSettingsEditDto
    {
        public bool AllowSelfRegistration { get; set; }

        public bool IsNewRegisteredTenantActiveByDefault { get; set; }

        public bool UseCaptchaOnRegistration { get; set; }

        public int? DefaultEditionId { get; set; }
        
    }
}