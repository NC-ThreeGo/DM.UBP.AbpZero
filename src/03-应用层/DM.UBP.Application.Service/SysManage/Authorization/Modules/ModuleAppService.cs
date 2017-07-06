using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.AutoMapper;
using DM.UBP.Application.Dto.SysManage.Authorization.Modules;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using TG.UBP.Domain.Service.SysManage.Authorization.Modules;

namespace DM.UBP.Application.Service.SysManage.Authorization.Modules
{
    /* THIS IS JUST A SAMPLE. */
    //TODO:修改成读取数据库的角色列表
    //[AbpAuthorize(PermissionNames.Pages_Users)]
    [DisableAuditing]
    public class ModuleAppService : UbpAppServiceBase, IModuleAppService
    {
        //private readonly IRepository<Module, int> _moduleRepository;
        private readonly ModuleManager _moduleManager;

        public ModuleAppService(ModuleManager moduleManager)
        {
            //_moduleRepository = moduleRepository;
            _moduleManager = moduleManager;
        }

        #region 模块
        public async Task<List<ModuleListDto>> GetAllModules()
        {
            var modules = await _moduleManager.GetAllModulesAsync();
            var moduleListDtos = modules.MapTo<List<ModuleListDto>>();

            return moduleListDtos;
        }

        public async Task<List<ModuleListDto>> GetModules(long? parentId)
        {
            var modules = await _moduleManager.GetModulesAsync(parentId);
            var moduleListDtos = modules.MapTo<List<ModuleListDto>>();

            //return new PagedResultDto<ModuleListDto>(
            //    modules.Count,
            //    moduleListDtos
            //    );
            return moduleListDtos;
        }

        public async Task<CreateModuleInput> GetModuleById(long id)
        {
            var module = await _moduleManager.GetModuleById(id);
            return module.MapTo<CreateModuleInput>();
        }

        public async Task<bool> CreateModule(CreateModuleInput input)
        {
            Module newModule = new Module()
            {
                TenantId = AbpSession.TenantId,
                ModuleCode = input.ModuleCode,
                ModuleName = input.ModuleName,
                ParentId = input.ParentId,
                Url = input.Url,
                Icon = input.Icon,
                Sort = input.Sort,
                Remark = input.Remark,
                EnabledMark = input.EnabledMark,
                IsLast = input.IsLast
            };
            return await _moduleManager.CreateModuleAsync(newModule);
        }

        public async Task<bool> UpdateModule(CreateModuleInput input)
        {
            var module = await _moduleManager.GetModuleById(input.Id.Value);
            module.ModuleCode = input.ModuleCode;
            module.ModuleName = input.ModuleName;
            module.ParentId = input.ParentId;
            module.Url = input.Url;
            module.Icon = input.Icon;
            module.Sort = input.Sort;
            module.Remark = input.Remark;
            module.EnabledMark = input.EnabledMark;
            module.IsLast = input.IsLast;

            return await _moduleManager.UpdateModuleAsync(module);
        }
        #endregion

        #region 模块的操作码
        public async Task<PagedResultDto<ModuleOperateDto>> GetModuleOperates(GetModuleIdInput input)
        {
            var moduleOperates = await _moduleManager.GetModuleOperatesAsync(input.ModuleId);
            var moduleOperateListDtos = moduleOperates.MapTo<List<ModuleOperateDto>>();

            return new PagedResultDto<ModuleOperateDto>(
                moduleOperates.Count,
                moduleOperateListDtos
                );
        }

        public async Task<ModuleOperateDto> GetModuleOperateById(long id)
        {
            var moduleOperate = await _moduleManager.GetModuleOperateById(id);
            return moduleOperate.MapTo<ModuleOperateDto>();
        }

        public async Task<bool> CreateModuleOperate(ModuleOperateDto input)
        {
            ModuleOperate newModuleOperate = new ModuleOperate()
            {
                OperateCode = input.OperateCode,
                OperateName = input.OperateName,
                ModuleId = input.ModuleId,
                IsValid = input.IsValid,
                Url = input.Url,
                Icon = input.Icon,
                Sort = input.Sort,
            };
            return await _moduleManager.CreateModuleOperateAsync(newModuleOperate);
        }

        public async Task<bool> UpdateModuleOperate(ModuleOperateDto input)
        {
            var moduleOpterate = _moduleManager.GetModuleOperateById(input.Id).Result;
            moduleOpterate.OperateCode = input.OperateCode;
            moduleOpterate.OperateName = input.OperateName;
            moduleOpterate.ModuleId = input.ModuleId;
            moduleOpterate.IsValid = input.IsValid;
            moduleOpterate.Url = input.Url;
            moduleOpterate.Icon = input.Icon;
            moduleOpterate.Sort = input.Sort;

            return await _moduleManager.UpdateModuleOperateAsync(moduleOpterate);
        }
        #endregion

        #region 模块的数据列过滤器
        public async Task<PagedResultDto<ModuleColumnFilterDto>> GetColumnFilters(GetModuleIdInput input)
        {
            var columnFilters = await _moduleManager.GetColumnFiltersAsync(input.ModuleId);
            var columnFilterListDtos = columnFilters.MapTo<List<ModuleColumnFilterDto>>();

            return new PagedResultDto<ModuleColumnFilterDto>(
                columnFilters.Count,
                columnFilterListDtos
                );
        }

        public async Task<ModuleColumnFilterDto> GetColumnFilterById(long id)
        {
            var columnFilter = await _moduleManager.GetColumnFilterById(id);
            return columnFilter.MapTo<ModuleColumnFilterDto>();
        }

        public async Task<bool> CreateColumnFilter(ModuleColumnFilterDto input)
        {
            ModuleColumnFilter newColumnFilter = new ModuleColumnFilter()
            {
                ColumnCode = input.ColumnCode,
                ColumnName = input.ColumnName,
                ModuleId = input.ModuleId,
                IsValid = input.IsValid,
                Sort = input.Sort,
            };
            return await _moduleManager.CreateColumnFilterAsync(newColumnFilter);
        }

        public async Task<bool> UpdateColumnFilter(ModuleColumnFilterDto input)
        {
            var newColumnFilter = _moduleManager.GetColumnFilterById(input.Id).Result;
            newColumnFilter.ColumnCode = input.ColumnCode;
            newColumnFilter.ColumnName = input.ColumnName;
            newColumnFilter.ModuleId = input.ModuleId;
            newColumnFilter.IsValid = input.IsValid;
            newColumnFilter.Sort = input.Sort;

            return await _moduleManager.UpdateColumnFilterAsync(newColumnFilter);
        }
        #endregion
    }
}