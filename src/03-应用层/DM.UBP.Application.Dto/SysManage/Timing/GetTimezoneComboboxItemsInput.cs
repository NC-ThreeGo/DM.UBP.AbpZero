using Abp.Configuration;

namespace DM.UBP.Application.Dto.SysManage.Timing
{
    public class GetTimezoneComboboxItemsInput
    {
        public SettingScopes DefaultTimezoneScope;

        public string SelectedTimezoneId { get; set; }
    }
}
