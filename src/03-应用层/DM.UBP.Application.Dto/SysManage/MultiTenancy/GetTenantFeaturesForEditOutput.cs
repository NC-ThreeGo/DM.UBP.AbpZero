using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Editions;
using System.Collections.Generic;

namespace DM.UBP.Application.Dto.SysManage.MultiTenancy
{
    public class GetTenantFeaturesForEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}