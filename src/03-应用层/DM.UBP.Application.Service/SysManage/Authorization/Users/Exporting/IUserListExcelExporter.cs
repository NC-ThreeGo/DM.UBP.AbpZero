using DM.UBP.Application.Dto.Common;
using DM.UBP.Application.Dto.SysManage.Authorization.Users;
using System.Collections.Generic;

namespace DM.UBP.Application.Service.SysManage.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}