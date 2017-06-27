using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DM.UBP.Domain.Entity.BaseManage.Permission;

namespace DM.UBP.Domain.SeedAction.SeedData
{
    public class RootModuleCreator
    {
        private readonly DbContext _context;

        static RootModuleCreator()
        {
        }

        public RootModuleCreator(DbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.Set<Module>().Add(new Module()
            {
                ModuleCode = "Root",
                ModuleName = "根菜单",
                Icon = "fa fa-television",
                IsDeleted = false,
                IsLast = false,
                Sort = 0,
                EnabledMark = true,
                CreationTime = DateTime.Now
            });
            _context.SaveChanges();
        }
    }
}
