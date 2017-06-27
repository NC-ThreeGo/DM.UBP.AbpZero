using DM.UBP.Domain.Entity.SysManage.Storage;
using System;
using System.Threading.Tasks;

namespace DM.UBP.Domain.Service.SysManage.Storage
{
    public interface IBinaryObjectManager
    {
        Task<BinaryObject> GetOrNullAsync(Guid id);
        
        Task SaveAsync(BinaryObject file);
        
        Task DeleteAsync(Guid id);
    }
}