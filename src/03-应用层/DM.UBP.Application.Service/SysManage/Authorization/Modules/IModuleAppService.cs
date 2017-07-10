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
        #region ģ��
        Task<List<ModuleListDto>> GetAllModules();

        Task<List<ModuleListDto>> GetModules(long? parentId);

        /// <summary>
        /// Ϊ������ȡģ���б�����AutoMapper�ĳ�ʼ������Nav��ʼ��֮�����Բ���ʹ��Dto����ֻ��ֱ�ӷ���ʵ���ࡣ
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<List<Module>> GetModulesForNav(long? parentId);

        Task<CreateModuleInput> GetModuleById(long id);

        Task<bool> CreateModule(CreateModuleInput input);
        Task<bool> UpdateModule(CreateModuleInput input);

        Task<string> GetModuleCodeByUrl(string url);
        #endregion

        #region ģ��Ĳ�����
        Task<PagedResultDto<ModuleOperateDto>> GetModuleOperates(GetModuleIdInput input);

        Task<ModuleOperateDto> GetModuleOperateById(long id);

        Task<bool> CreateModuleOperate(ModuleOperateDto input);
        Task<bool> UpdateModuleOperate(ModuleOperateDto input);
        #endregion

        #region ģ��������й�����
        Task<PagedResultDto<ModuleColumnFilterDto>> GetColumnFilters(GetModuleIdInput input);

        Task<ModuleColumnFilterDto> GetColumnFilterById(long id);

        Task<bool> CreateColumnFilter(ModuleColumnFilterDto input);
        Task<bool> UpdateColumnFilter(ModuleColumnFilterDto input);
        #endregion
    }
}