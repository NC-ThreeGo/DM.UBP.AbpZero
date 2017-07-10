using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DM.UBP.Application.Dto.SysManage.Authorization.Modules;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DM.UBP.Application.Service.SysManage.Authorization.Modules
{
    public interface IModuleAppService : IApplicationService
    {
        #region 模块
        Task<List<ModuleListDto>> GetAllModules();

        Task<List<ModuleListDto>> GetModules(long? parentId);

        /// <summary>
        /// 为导航获取模块列表，由于AutoMapper的初始化是在Nav初始化之后，所以不能使用Dto对象，只能直接返回实体类。
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<Module>> GetModulesForNav(long? parentId);

        Task<CreateModuleInput> GetModuleById(long id);

        Task<bool> CreateModule(CreateModuleInput input);
        Task<bool> UpdateModule(CreateModuleInput input);

        Task<string> GetModuleCodeByUrl(string url);
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