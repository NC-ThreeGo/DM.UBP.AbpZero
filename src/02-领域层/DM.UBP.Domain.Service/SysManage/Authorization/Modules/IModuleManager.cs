using Abp.Domain.Services;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TG.UBP.Domain.Service.SysManage.Authorization.Modules
{
    public interface IModuleManager : IDomainService
    {
        #region 模块
        Task<List<Module>> GetAllModulesAsync();

        Task<List<Module>> GetModulesAsync(long? parentId);

        Task<Module> GetModuleById(long id);

        Task<bool> CreateModuleAsync(Module module);

        Task<bool> UpdateModuleAsync(Module module);

        /// <summary>
        /// 根据URL获取模块编码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<Module> GetModuleByUrlAsync(string url);
        #endregion

        #region 模块的操作码
        Task<List<ModuleOperate>> GetModuleOperatesAsync(long moduleId);

        Task<ModuleOperate> GetModuleOperateById(long id);

        Task<bool> CreateModuleOperateAsync(ModuleOperate moduleOperate);

        Task<bool> UpdateModuleOperateAsync(ModuleOperate moduleOperate);
        #endregion

        #region 模块的数据列过滤器
        Task<List<ModuleColumnFilter>> GetColumnFiltersAsync(long moduleId);

        Task<ModuleColumnFilter> GetColumnFilterById(long id);

        Task<bool> CreateColumnFilterAsync(ModuleColumnFilter columnFilter);

        Task<bool> UpdateColumnFilterAsync(ModuleColumnFilter columnFilter);
        #endregion
    }
}
