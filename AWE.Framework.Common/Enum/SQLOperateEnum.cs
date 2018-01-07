using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Enum
{
    /// <summary>
    /// 数据库操作枚举类
    /// </summary>
    [Serializable]
    [Flags]
    public enum SQLOperateEnum
    {
        /// <summary>
        /// 无操作
        /// </summary>
        None = 1,

        /// <summary>
        /// 查询
        /// </summary>
        Select = 2,

        /// <summary>
        /// 插入
        /// </summary>
        Insert = 4,

        /// <summary>
        /// 更新
        /// </summary>
        Update = 8,

        /// <summary>
        /// 删除
        /// </summary>
        Delete = 16,

        /// <summary>
        ///  所以操作
        /// </summary>
        All = 32
    }
}
