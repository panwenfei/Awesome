using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Enum
{
    /// <summary>
    /// 事务级别枚举
    /// </summary>
    [Serializable]
    public enum IsolationLevelEnum
    {
        /// <summary>
        /// 启动默认事务
        /// </summary>
        Default,

        /// <summary>
        /// 无法改写隔离级别更高的事务中的挂起的更改
        /// </summary>
        Chaos,

        /// <summary>
        /// 默认级别，在正在读取数据时保持共享锁，以避免脏读，但是在事务结束之前可以更改数据，从而导致不可重复的读取或幻像数据
        /// </summary>
        ReadCommitted,

        /// <summary>
        /// 可以进行脏读，意思是说，不发布共享锁，也不接受独占锁
        /// </summary>
        ReadUncommitted,

        /// <summary>
        /// 在查询中使用的所有数据上放置锁，以防止其他用户更新这些数据。防止不可重复的读取，但是仍可以有幻像行
        /// </summary>
        RepeatableRead,

        /// <summary>
        /// 在 System.Data.DataSet 上放置范围锁，以防止在事务完成之前由其他用户更新行或向数据集中插入行
        /// </summary>
        Serializable,

        /// <summary>
        /// 正在使用与指定隔离级别不同的隔离级别，但是无法确定该级别
        /// </summary>
        Unspecified
    }
}
