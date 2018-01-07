using AWE.Framework.Common.Enum;
using AWE.Framework.DataAccess.Interface;
using AWE.Framework.DataAccess.SQLHelper;
using AWE.Framework.DataAccess.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.DataAccess.DBFactory
{
    /// <summary>
    /// 工厂方法实现
    /// </summary>
    public sealed class DBFactory
    {
        /// <summary>
        /// 获取默认的数据访问对象实例
        /// </summary>
        /// <returns></returns>
        public static IDBHelper GetDBHelper()
        {
            IDBHelper dbHelper = null;
            Connector db = Connector.GetInstance();
            switch (db.DataBaseType)
            {
                case DataBaseTypeEnum.SQLServer:
                    dbHelper = new DBHelper(db.DataBaseConnection);
                    break;
            }
            return dbHelper;
        }

        /// <summary>
        /// 获取默认的数据访问实例
        /// </summary>
        /// <returns></returns>
        public static IDBHelper GetDBHelper(DataBaseTypeEnum dbType, string dbConnection)
        {
            IDBHelper dbHelper = null;
            switch (dbType)
            {
                case DataBaseTypeEnum.SQLServer:
                    dbHelper = new DBHelper(dbConnection);
                    break;
            }
            return dbHelper;
        }

    }
}
