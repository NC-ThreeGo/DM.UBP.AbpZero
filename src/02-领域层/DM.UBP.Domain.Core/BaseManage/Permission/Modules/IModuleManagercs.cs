using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TG.UBP.Core.LinqHelper;
using TG.UBP.Domain.Entity.BaseManage.Permission;

namespace TG.UBP.Domain.Core.BaseManage.Permission.Modules
{
    public interface IModuleManagercs : IDomainService
    {
        #region 模块
        Task<List<Module>> GetModules(long parentId);

        Module GetModuleById(long id);

        Task<bool> CreateModuleAsync(Module module);

        Task<bool> UpdateModuleAsync(Module module);
        #endregion

        #region 模块的操作码
        List<ModuleOperate> GetModuleOperates(ref GridPager pager, int moduleId);

        Task<ModuleOperate> GetModuleOperateById(int id);

        Task<bool> CreateModuleOperateAsync(ModuleOperate moduleOperate);

        Task<bool> UpdateModuleOperateAsync(ModuleOperate moduleOperate);
        #endregion

        #region 模块的数据列过滤器
        List<ModuleColumnFilter> GetColumnFilters(ref GridPager pager, int moduleId);

        Task<ModuleColumnFilter> GetColumnFilterById(int id);

        Task<bool> CreateColumnFilterAsync(ModuleColumnFilter columnFilter);

        Task<bool> UpdateColumnFilterAsync(ModuleColumnFilter columnFilter);
        #endregion
    }
}
