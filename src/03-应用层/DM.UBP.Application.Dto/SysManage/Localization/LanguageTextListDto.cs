using Abp.Application.Services.Dto;

namespace DM.UBP.Application.Dto.SysManage.Localization
{
    public class LanguageTextListDto
    {
        public string Key { get; set; }
        
        public string BaseValue { get; set; }
        
        public string TargetValue { get; set; }
    }
}