using Abp.Runtime.Validation;
using DM.UBP.Application.Dto.Common;

namespace DM.UBP.Application.Dto.SysManage.MultiTenancy
{
    public class GetTenantsInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "TenancyName";
            }

            Sorting = Sorting.Replace("editionDisplayName", "Edition.DisplayName");
        }
    }
}

