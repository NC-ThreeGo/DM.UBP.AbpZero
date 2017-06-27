using Abp.Localization;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DM.UBP.Domain.SeedAction.SeedData
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages { get; private set; }

        private readonly DbContext _context;

        static DefaultLanguagesCreator()
        {
            InitialLanguages = new List<ApplicationLanguage>
            {
                new ApplicationLanguage(null, "en", "English", "famfamfam-flag-gb"),
                new ApplicationLanguage(null, "tr", "Türkçe", "famfamfam-flag-tr"),
                new ApplicationLanguage(null, "zh-CN", "简体中文", "famfamfam-flag-cn"),
                new ApplicationLanguage(null, "pt-BR", "Português-BR", "famfamfam-flag-br"),
                new ApplicationLanguage(null, "es", "Español", "famfamfam-flag-es"),
                new ApplicationLanguage(null, "fr", "Français", "famfamfam-flag-fr"),
                new ApplicationLanguage(null, "it", "Italiano", "famfamfam-flag-it"),
                new ApplicationLanguage(null, "ja", "日本語", "famfamfam-flag-jp"),
                new ApplicationLanguage(null, "nl-NL", "Nederlands", "famfamfam-flag-nl"),
                new ApplicationLanguage(null, "lt", "Lietuvos", "famfamfam-flag-lt"),
                new ApplicationLanguage(null, "vi", "Vietnamese", "famfamfam-flag-vi")
            };
        }

        public DefaultLanguagesCreator(DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Set<ApplicationLanguage>().Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Set<ApplicationLanguage>().Add(language);

            _context.SaveChanges();
        }
    }
}
