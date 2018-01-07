using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Enum
{
    /// <summary>
    /// Sql Command类型的枚举类
    /// </summary>
    [Serializable]
    public enum CommandTypeEnum
    {
        /// <summary>
        /// Sql语句
        /// </summary>
        Text,

        /// <summary>
        /// 存贮过程
        /// </summary>
        StoredProcedure,

        /// <summary>
        /// 表
        /// </summary>
        TableDirect
    }
}
