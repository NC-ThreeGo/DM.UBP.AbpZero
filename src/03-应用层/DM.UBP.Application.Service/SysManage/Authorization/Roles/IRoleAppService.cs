using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Authorization.Roles;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Authorization.Roles
{
    /// <summary>
    /// Application service that is used by 'role management' page.
    /// </summary>
    public interface IRoleAppService : IApplicationService
    {
        Task<ListResultDto<RoleListDto>> GetRoles(GetRolesInput input);

        Task<GetRoleForEditOutput> GetRoleForEdit(NullableIdDto input);

        Task CreateOrUpdateRole(CreateOrUpdateRoleInput input);

        Task DeleteRole(EntityDto input);
    }
}