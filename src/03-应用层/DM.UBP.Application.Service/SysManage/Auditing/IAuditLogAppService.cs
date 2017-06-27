using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.Common;
using DM.UBP.Application.Dto.SysManage.Auditing;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Auditing
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultDto<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

        Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);
    }
}