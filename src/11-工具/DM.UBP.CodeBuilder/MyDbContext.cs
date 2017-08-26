using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.UBP.CodeBuilder
{
    public class MyDbContext : DbContext
    {

        #region Constructors

        public MyDbContext()
          : base()
        {
        }

        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public MyDbContext(DbConnection connection)
          : base(connection, true)
        {
        }

        #endregion
    }

    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Int16 Length { get; set; }

        public Byte Scale { get; set; }

        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsIdentity { get; set; }

        public bool Nullable { get; set; }

        public string Comments { get; set; }

        public bool IsPk { get; set; }
    }
}
