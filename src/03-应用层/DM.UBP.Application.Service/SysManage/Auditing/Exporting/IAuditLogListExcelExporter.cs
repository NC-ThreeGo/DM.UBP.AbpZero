using DM.UBP.Application.Dto.Common;
using DM.UBP.Application.Dto.SysManage.Auditing;
using System.Collections.Generic;

namespace DM.UBP.Application.Service.SysManage.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
