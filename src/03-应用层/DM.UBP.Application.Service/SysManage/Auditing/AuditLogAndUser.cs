using Abp.Auditing;
using DM.UBP.Domain.Entity.SysManage.Authorization;

namespace DM.UBP.Application.Service.SysManage.Auditing
{
    /// <summary>
    /// A helper class to store an <see cref="AuditLog"/> and a <see cref="User"/> object.
    /// </summary>
    public class AuditLogAndUser
    {
        public AuditLog AuditLog { get; set; }

        public User User { get; set; }
    }
}