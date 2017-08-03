using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.UBP.Core.Authorization
{
    /// <summary>
    /// 验证类别
    /// </summary>
    public enum UbpAuthorizeType
    {
        /// <summary>
        /// 模块
        /// </summary>
        Module = 0,

        /// <summary>
        /// 模块的操作码
        /// </summary>
        Operate = 1,

        /// <summary>
        /// 模块的列过滤器
        /// </summary>
        ColumnFilter = 2,
    }
}
