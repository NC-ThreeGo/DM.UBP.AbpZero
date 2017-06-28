using DM.UBP.Application.Dto.SysManage.Caching;
using System.Collections.Generic;

namespace DM.UBP.Web.Areas.Mpa.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}