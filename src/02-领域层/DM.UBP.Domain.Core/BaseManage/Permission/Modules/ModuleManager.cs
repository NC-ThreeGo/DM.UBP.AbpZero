using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TG.UBP.Core.LinqHelper;
using TG.UBP.Domain.Entity.BaseManage.Permission;

namespace TG.UBP.Domain.Core.BaseManage.Permission.Modules
{
    public class ModuleManager : DomainService, IModuleManagercs
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        private readonly IRepository<Module, long> _moduleRepository;
        private readonly IRepository<ModuleOperate, int> _moduleOperateRepository;
        private readonly IRepository<ModuleColumnFilter, int> _columnFilterRepository;

        public ModuleManager(
            IUnitOfWorkManager unitOfWorkManager, 
            IRepository<Module, long> moduleRepository,
            IRepository<ModuleOperate, int> moduleOperateRepository,
            IRepository<ModuleColumnFilter, int> columnFilterRepository
            )
        {
            _unitOfWorkManager = unitOfWorkManager;
            _moduleRepository = moduleRepository;
            _moduleOperateRepository = moduleOperateRepository;
            _columnFilterRepository = columnFilterRepository;
        }

        #region 模块
        public async Task<List<Module>> GetModules(long parentId)
        {
            var modules = _moduleRepository.GetAll().Where(p => p.ParentId == parentId).OrderBy(p => p.Sort);
            return await modules.ToListAsync();
        }

        public Module GetModuleById(long id)
        {
            return _moduleRepository.Get(id);
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
        #endregion

        #region 模块的操作码
        public List<ModuleOperate> GetModuleOperates(ref GridPager pager, int moduleId)
        {
            var moduleOperates = _moduleOperateRepository.GetAll().Where(p => p.ModuleId == moduleId);
            pager.totalRows = moduleOperates.Count();
            //排序
            moduleOperates = LinqHelper.SortingAndPaging(moduleOperates, pager.sort, pager.order, pager.page, pager.rows);

            return  moduleOperates.ToList();
        }

        public async Task<ModuleOperate>  GetModuleOperateById(int id)
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

        #region 模块的数据列过滤器
        public List<ModuleColumnFilter> GetColumnFilters(ref GridPager pager, int moduleId)
        {
            var columnFilters = _columnFilterRepository.GetAll().Where(p => p.ModuleId == moduleId);
            pager.totalRows = columnFilters.Count();
            //排序
            columnFilters = LinqHelper.SortingAndPaging(columnFilters, pager.sort, pager.order, pager.page, pager.rows);

            return columnFilters.ToList();
        }

        public async Task<ModuleColumnFilter> GetColumnFilterById(int id)
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
