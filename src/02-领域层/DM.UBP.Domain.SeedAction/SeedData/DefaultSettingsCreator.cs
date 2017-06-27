using Abp.Configuration;
using Abp.Localization;
using Abp.Net.Mail;
using System.Data.Entity;
using System.Linq;

namespace DM.UBP.Domain.SeedAction.SeedData
{
    public class DefaultSettingsCreator
    {
        private readonly DbContext _context;

        public DefaultSettingsCreator(DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            //Emailing
            AddSettingIfNotExists(EmailSettingNames.DefaultFromAddress, "admin@mydomain.com");
            AddSettingIfNotExists(EmailSettingNames.DefaultFromDisplayName, "mydomain.com mailer");

            //Languages
            AddSettingIfNotExists(LocalizationSettingNames.DefaultLanguage, "en");
        }

        private void AddSettingIfNotExists(string name, string value, int? tenantId = null)
        {
            if (_context.Set<Setting>().Any(s => s.Name == name && s.TenantId == tenantId && s.UserId == null))
            {
                return;
            }

            _context.Set<Setting>().Add(new Setting(tenantId, null, name, value));
            _context.SaveChanges();
        }
    }
}