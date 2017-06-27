using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.Common;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<ComboboxItemDto>> GetEditionsForCombobox();

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        string GetDefaultEditionName();
    }
}