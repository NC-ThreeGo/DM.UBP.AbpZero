using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Configuration.Host;
using System.Collections.Generic;

namespace DM.UBP.Web.Areas.Mpa.Models.HostSettings
{
    public class HostSettingsViewModel
    {
        public HostSettingsEditDto Settings { get; set; }

        public List<ComboboxItemDto> EditionItems { get; set; }

        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}