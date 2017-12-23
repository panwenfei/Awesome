using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Enum
{
    /// <summary>
    /// 数据库类型枚举类
    /// </summary>
    [Serializable]
    public enum DataBaseTypeEnum
    {
        /// <summary>
        /// 未知，跑出异常
        /// </summary>
        Unknown,

        /// <summary>
        /// SQLServer数据库
        /// </summary>
        SQLServer,

        /// <summary>
        /// Oracle数据库
        /// </summary>
        Oracle,

        /// <summary>
        /// Access数据库
        /// </summary>
        Access
    }
}
