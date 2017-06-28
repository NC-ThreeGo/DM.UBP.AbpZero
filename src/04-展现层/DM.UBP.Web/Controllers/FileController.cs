using Abp.Auditing;
using Abp.UI;
using Abp.Web.Mvc.Authorization;
using DM.UBP.Application.Dto.Common;
using DM.UBP.Domain.Service.SysManage.Folders;
using System.IO;
using System.Web.Mvc;

namespace DM.UBP.Web.Controllers
{
    public class FileController : UbpControllerBase
    {
        private readonly IAppFolders _appFolders;

        public FileController(IAppFolders appFolders)
        {
            _appFolders = appFolders;
        }

        [AbpMvcAuthorize]
        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            var filePath = Path.Combine(_appFolders.TempFileDownloadFolder, file.FileToken);
            if (!System.IO.File.Exists(filePath))
            {
                throw new UserFriendlyException(L("RequestedFileDoesNotExists"));
            }

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            System.IO.File.Delete(filePath);
            return File(fileBytes, file.FileType, file.FileName);
        }
    }
}