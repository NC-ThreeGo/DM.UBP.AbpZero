using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Authorization.Permissions;

namespace DM.UBP.Application.Service.SysManage.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
