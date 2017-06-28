using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Editions;
using System.Collections.Generic;

namespace DM.UBP.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}