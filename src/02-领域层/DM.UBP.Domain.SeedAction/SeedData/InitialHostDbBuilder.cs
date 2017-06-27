using EntityFramework.DynamicFilters;
using System.Data.Entity;

namespace DM.UBP.Domain.SeedAction.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly DbContext _context;

        public InitialHostDbBuilder(DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new RootModuleCreator(_context).Create();
        }
    }
}
