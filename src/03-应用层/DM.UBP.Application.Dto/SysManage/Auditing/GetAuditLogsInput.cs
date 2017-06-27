using Abp.Extensions;
using Abp.Runtime.Validation;
using DM.UBP.Application.Dto.Common;
using System;

namespace DM.UBP.Application.Dto.SysManage.Auditing
{
    public class GetAuditLogsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public string UserName { get; set; }
        
        public string ServiceName { get; set; }

        public string MethodName { get; set; }

        public string BrowserInfo { get; set; }
        
        public bool? HasException { get; set; }

        public int? MinExecutionDuration { get; set; }
        
        public int? MaxExecutionDuration { get; set; }

        public void Normalize()
        {
            if (Sorting.IsNullOrWhiteSpace())
            {
                Sorting = "ExecutionTime DESC";
            }

            if (Sorting.IndexOf("UserName", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                Sorting = "User." + Sorting;
            }
            else
            {
                Sorting = "AuditLog." + Sorting;
            }
        }
    }
}