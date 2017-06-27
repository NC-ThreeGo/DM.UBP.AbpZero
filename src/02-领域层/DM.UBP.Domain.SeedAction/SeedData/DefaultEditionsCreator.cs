using Abp.Application.Editions;
using System.Data.Entity;
using System.Linq;
using DM.UBP.Domain.Core.BaseManage.Editions;

namespace DM.UBP.Domain.SeedAction.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly DbContext _context;

        public DefaultEditionsCreator(DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Set<Edition>().FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Set<Edition>().Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }
        }
    }
}