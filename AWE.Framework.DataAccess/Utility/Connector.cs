using AWE.Framework.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.DataAccess.Utility
{
    /// <summary>
    /// 从配置文件中读取连接字符串，生成单件实例
    /// </summary>
    internal sealed class Connector
    {
        private DataBaseTypeEnum p_DBType;
        private string p_ConnectionString;
        private static volatile Connector instance;
        private static object syncRoot = new object();

        /// <summary>
        /// 后遭函数，用于读取数据配置信息
        /// </summary>
        private Connector()
        {
            //数据库类型
            p_DBType = Config.DBType;
            if (p_DBType == DataBaseTypeEnum.Unknown)
            {
                //ErrorHandler.ThrowTechnologyError(new Error("数据库连接类型未设置！"));
            }
            //连接数据库字符串
            p_ConnectionString = Config.DBConnection;
            if (p_ConnectionString.Trim() == "")
            {
                //ErrorHandler.ThrowTechnologyError(new Error("数据库连接字符串未设置！"));
            }
        }

        /// <summary>
        /// 默认的数据库类型
        /// </summary>
        internal DataBaseTypeEnum DataBaseType
        {
            get { return p_DBType; }
            set { p_DBType = value; }
        }

        /// <summary>
        /// 默认的数据库连接字符串
        /// </summary>
        internal string DataBaseConnection
        {
            get { return p_ConnectionString; }
            set { p_ConnectionString = value; }
        }

        /// <summary>
        /// 获得单件实例
        /// </summary>
        /// <returns>单件实例</returns>
        internal static Connector GetInstance()
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    instance = new Connector();
                }
            }
            return instance;
        }
    }
}
