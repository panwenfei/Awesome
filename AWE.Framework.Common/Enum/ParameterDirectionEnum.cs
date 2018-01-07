using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Enum
{
    /// <summary>
    /// 参数方向枚举
    /// </summary>
    [Serializable]
    public enum ParameterDirectionEnum
    {
        /// <summary>
        /// 参数是输入参数
        /// </summary>
        Input,

        /// <summary>
        /// 参数既能输入，也能输出
        /// </summary>
        InputOutput,

        /// <summary>
        /// 参数是输出参数
        /// </summary>
        Output,

        /// <summary>
        /// 参数表示诸如存储过程、内置函数或用户定义函数之类的操作的返回值
        /// </summary>
        ReturnValue
    }
}
