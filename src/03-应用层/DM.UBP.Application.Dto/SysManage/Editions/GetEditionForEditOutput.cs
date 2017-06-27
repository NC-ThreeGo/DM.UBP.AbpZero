using System.Collections.Generic;
using Abp.Application.Services.Dto;

namespace DM.UBP.Application.Dto.SysManage.Editions
{
    public class GetEditionForEditOutput
    {
        public EditionEditDto Edition { get; set; }

        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}