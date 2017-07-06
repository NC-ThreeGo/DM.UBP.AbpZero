using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Authorization.Modules;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Authorization.Modules
{
    public interface IModuleAppService : IApplicationService
    {
        #region 模块
        Task<List<ModuleListDto>> GetAllModules();

        Task<List<ModuleListDto>> GetModules(long? parentId);

        Task<CreateModuleInput> GetModuleById(long id);

        Task<bool> CreateModule(CreateModuleInput input);
        Task<bool> UpdateModule(CreateModuleInput input);
        #endregion

        #region 模块的操作码
        Task<PagedResultDto<ModuleOperateDto>> GetModuleOperates(GetModuleIdInput input);

        Task<ModuleOperateDto> GetModuleOperateById(long id);

        Task<bool> CreateModuleOperate(ModuleOperateDto input);
        Task<bool> UpdateModuleOperate(ModuleOperateDto input);
        #endregion

        #region 模块的数据列过滤器
        Task<PagedResultDto<ModuleColumnFilterDto>> GetColumnFilters(GetModuleIdInput input);

        Task<ModuleColumnFilterDto> GetColumnFilterById(long id);

        Task<bool> CreateColumnFilter(ModuleColumnFilterDto input);
        Task<bool> UpdateColumnFilter(ModuleColumnFilterDto input);
        #endregion
    }
}