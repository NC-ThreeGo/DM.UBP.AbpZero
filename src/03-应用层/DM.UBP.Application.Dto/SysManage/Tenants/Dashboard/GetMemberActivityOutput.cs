using System.Collections.Generic;

namespace DM.UBP.Application.Dto.SysManage.Tenants.Dashboard
{
    public class GetMemberActivityOutput
    {
        public List<int> TotalMembers { get; set; }

        public List<int> NewMembers { get; set; }
    }
}