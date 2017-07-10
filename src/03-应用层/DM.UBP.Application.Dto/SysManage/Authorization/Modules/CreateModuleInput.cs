using Abp.AutoMapper;
using Abp.MultiTenancy;
using DM.UBP.Domain.Entity.SysManage.Authorization;
using System.ComponentModel.DataAnnotations;

namespace DM.UBP.Application.Dto.SysManage.Authorization.Modules
{
    [AutoMapFrom(typeof(Module))]
    public class CreateModuleInput
    {
        //[NotNullExpression]
        [Display(Name = "ID")]
        public long? Id { get; set; }

        //[Required]
        [Display(Name = "�ϼ�ID")]
        public long? ParentId { get; set; }

        [Display(Name = "ģ�����")]
        [Required]
        public string ModuleCode { get; set; }

        [Display(Name = "ģ������")]
        [Required]
        public string ModuleName { get; set; }

        [Display(Name = "Url")]
        public string Url { get; set; }

        [Display(Name = "ͼ��")]
        public string Icon { get; set; }

        [Display(Name = "�����")]
        public int Sort { get; set; }

        [Display(Name = "˵��")]
        public string Remark { get; set; }

        [Display(Name = "״̬")]
        public bool EnabledMark { get; set; }

        [Display(Name = "�Ƿ����һ��")]
        public bool IsLast { get; set; }

        [Display(Name = "���⻧ģʽ")]
        [Required]
        public MultiTenancySides MultiTenancySide { get; set; }

        /// <summary>
        /// �Ƿ����޸�״̬�����Id��ֵ���ʾ�޸ķ����ʾ������
        /// </summary>
        public bool IsEditMode
        {
            get { return Id.HasValue; }
        }
    }
}