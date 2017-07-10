using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace TG.UBP.Domain.Service.SysManage.Authorization.Modules
{
    public class ModuleManager : DomainService, IModuleManager
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        private readonly IRepository<Module, long> _moduleRepository;
        private readonly IRepository<ModuleOperate, long> _moduleOperateRepository;
        private readonly IRepository<ModuleColumnFilter, long> _columnFilterRepository;

        public ModuleManager(
            IUnitOfWorkManager unitOfWorkManager, 
            IRepository<Module, long> moduleRepository,
            IRepository<ModuleOperate, long> moduleOperateRepository,
            IRepository<ModuleColumnFilter, long> columnFilterRepository
            )
        {
            _unitOfWorkManager = unitOfWorkManager;
            _moduleRepository = moduleRepository;
            _moduleOperateRepository = moduleOperateRepository;
            _columnFilterRepository = columnFilterRepository;
        }

        #region 模块
        public Task<List<Module>> GetAllModulesAsync()
        {
            var modules = _moduleRepository.GetAll().OrderBy(p => p.ParentId).ThenBy(p => p.Sort);
            return Task.FromResult(modules.ToList());
        }

        public Task<List<Module>> GetModulesAsync(long? parentId)
        {
            var modules = _moduleRepository.GetAll().Where(p => p.ParentId == parentId).OrderBy(p => p.Sort);
            return Task.FromResult(modules.ToList());
        }

        public async Task<Module> GetModuleById(long id)
        {
            return await _moduleRepository.GetAsync(id);
        }

        public async Task<bool> CreateModuleAsync(Module module)
        {
            Module newModule = null;
            newModule = await _moduleRepository.InsertAsync(module);
            return newModule != null;
        }

        public async Task<bool> UpdateModuleAsync(Module module)
        {
            Module newModule = null;
            newModule = await _moduleRepository.UpdateAsync(module);
            return newModule != null;
        }

        /// <summary>
        /// 根据URL获取模块编码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetModuleCodeByUrlAsync(string url)
        {
            string urlDefaultAction = url;
            if (url.Substring(url.Length - 5, 5) == "Index")
                urlDefaultAction = url.Substring(0, url.Length - 6);
            var module = await _moduleRepository.FirstOrDefaultAsync(p => p.Url == url || p.Url == urlDefaultAction);
            if (module != null)
                return module.ModuleCode;
            else
                return null;
        }
        #endregion

        #region 模块的操作码
        public Task<List<ModuleOperate>> GetModuleOperatesAsync(long moduleId)
        {
            var moduleOperates = _moduleOperateRepository.GetAll().Where(p => p.ModuleId == moduleId).OrderBy(p => p.Sort);

            return Task.FromResult(moduleOperates.ToList());
        }

        public async Task<ModuleOperate>  GetModuleOperateById(long id)
        {
            return await _moduleOperateRepository.GetAsync(id);
        }

        public async Task<bool> CreateModuleOperateAsync(ModuleOperate moduleOperate)
        {
            ModuleOperate newModuleOperate = null;
            newModuleOperate = await _moduleOperateRepository.InsertAsync(moduleOperate);
            return newModuleOperate != null;
        }

        public async Task<bool> UpdateModuleOperateAsync(ModuleOperate moduleOperate)
        {
            ModuleOperate newModuleOperate = null;
            newModuleOperate = await _moduleOperateRepository.UpdateAsync(moduleOperate);
            return newModuleOperate != null;
        }
        #endregion

        #region 模块的列过滤器
        public Task<List<ModuleColumnFilter>> GetColumnFiltersAsync(long moduleId)
        {
            var columnFilters = _columnFilterRepository.GetAll().Where(p => p.ModuleId == moduleId).OrderBy(p => p.Sort);
            return Task.FromResult(columnFilters.ToList());
        }

        public async Task<ModuleColumnFilter> GetColumnFilterById(long id)
        {
            return await _columnFilterRepository.GetAsync(id);
        }

        public async Task<bool> CreateColumnFilterAsync(ModuleColumnFilter columnFilter)
        {
            ModuleColumnFilter newColumnFilter = null;
            newColumnFilter = await _columnFilterRepository.InsertAsync(columnFilter);
            return newColumnFilter != null;
        }

        public async Task<bool> UpdateColumnFilterAsync(ModuleColumnFilter columnFilter)
        {
            ModuleColumnFilter newColumnFilter = null;
            newColumnFilter = await _columnFilterRepository.UpdateAsync(columnFilter);
            return newColumnFilter != null;
        }
        #endregion
    }
}
