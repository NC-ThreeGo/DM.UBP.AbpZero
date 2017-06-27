using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Organizations
{
    public class MoveOrganizationUnitInput
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public long? NewParentId { get; set; }
    }
}