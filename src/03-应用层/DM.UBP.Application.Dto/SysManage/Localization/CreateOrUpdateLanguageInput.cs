using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace DM.UBP.Application.Dto.SysManage.Localization
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}