using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Enum
{
    /// <summary>
    /// 数据类型的枚举类
    /// </summary>
    [Serializable]
    public enum DataTypeEnum
    {
        /// <summary>
        /// 默认，将从数据库中推倒出类型
        /// </summary>
        Default,

        /// <summary>
        /// 整数类型
        /// </summary>
        Integer,

        /// <summary>
        /// 长整数类型
        /// </summary>
        Long,

        /// <summary>
        /// 32位小数类型
        /// </summary>
        Float,

        /// <summary>
        /// 64位小数类型
        /// </summary>
        Double,

        /// <summary>
        /// 货币类型
        /// </summary>
        Decimal,

        /// <summary>
        /// 字符类型
        /// </summary>
        String,

        /// <summary>
        /// 日期类型
        /// </summary>
        DateTime,

        /// <summary>
        /// Boolean
        /// </summary>
        Boolean,

        /// <summary>
        /// 
        /// </summary>
        Object,

        /// <summary>
        /// 二进制类型
        /// </summary>
        Byte,

        /// <summary>
        /// 二进制类型
        /// </summary>
        Image,

        /// <summary>
        /// 二进制类型
        /// </summary>
        Uniqueidentifier
    }
}
