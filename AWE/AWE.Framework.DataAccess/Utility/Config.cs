using AWE.Framework.Common.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.DataAccess.Utility
{
    /// <summary>
    /// 从配置文件中读取相关设置
    /// </summary>
    internal sealed class Config
    {
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public static DataBaseTypeEnum DBType
        {
            get
            {
                DataBaseTypeEnum db = new DataBaseTypeEnum();
                string dbType = ConfigurationSettings.AppSettings["DBType"].ToUpper().Trim();
                switch (dbType)
                {
                    case "SQLSERVER":
                        db = DataBaseTypeEnum.SQLServer;
                        break;
                    case "ORACLE":
                        db = DataBaseTypeEnum.Oracle;
                        break;
                    case "ACCESS":
                        db = DataBaseTypeEnum.Access;
                        break;
                }
                return db;
            }
        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DBConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            }
        }
    }
}
