using Abp.Application.Services;
using DM.UBP.Application.Dto.Common;
using DM.UBP.Application.Dto.SysManage.Logging;

namespace DM.UBP.Application.Service.SysManage.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
