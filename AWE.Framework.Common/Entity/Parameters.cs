using AWE.Framework.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common
{
    public sealed class Parameters
    {
        private int p_size;
        private string p_paramName;
        private object p_paramValue;
        private DataTypeEnum p_paramType;
        private ParameterDirectionEnum p_paramDir;

        /// <summary>
        /// 构造器
        /// </summary>
        public Parameters()
            : this("", null)
        {
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="paramValue">参数值</param>
        public Parameters(string paramName, object paramValue)
            : this(paramName, DataTypeEnum.Default, paramValue, 0, ParameterDirectionEnum.Input)
        {
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="paramValue">参数值</param>
        /// <param name="paramType">参数类型</param>
        public Parameters(string paramName, DataTypeEnum paramType)
            : this(paramName, paramType, 0)
        {
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="paramValue">参数值</param>
        /// <param name="paramType">参数类型</param>
        public Parameters(string paramName, DataTypeEnum paramType, int size)
            : this(paramName, paramType, null, size, ParameterDirectionEnum.Input)
        {
        }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="paramName">参数名</param>
        /// <param name="paramValue">参数值</param>
        /// <param name="paramType">参数类型</param>
        /// <param name="paramDirect">参数方向</param>
        public Parameters(string paramName, DataTypeEnum paramType, object paramValue, int size, ParameterDirectionEnum paramDirect)
        {
            p_paramName = paramName;
            p_paramValue = paramValue;
            p_paramType = paramType;
            p_paramDir = paramDirect;
            p_size = size;
        }


        /// <summary>
        /// 参数名
        /// </summary>
        public string ParameterName
        {
            get { return p_paramName; }
            set { p_paramName = value; }
        }

        /// <summary>
        /// 参数值
        /// </summary>
        public object ParameterValue
        {
            get { return p_paramValue; }
            set { p_paramValue = value; }
        }

        /// <summary>
        /// 参数类型
        /// </summary>
        public DataTypeEnum ParameterType
        {
            get { return p_paramType; }
            set { p_paramType = value; }
        }

        /// <summary>
        /// 大小
        /// </summary>
        public int ParameterSize
        {
            get { return p_size; }
            set { p_size = value; }
        }

        /// <summary>
        /// 参数方向
        /// </summary>
        public ParameterDirectionEnum ParameterDirection
        {
            get { return p_paramDir; }
            set { p_paramDir = value; }
        }
    }
}
