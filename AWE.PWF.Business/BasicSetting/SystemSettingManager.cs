using AWE.Framework.DataAccess.DBFactory;
using AWE.Framework.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.PWF.Business
{
    public class SystemSettingManager
    {
        protected static IDBHelper DBHelper = DBFactory.GetDBHelper();

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFunctionList()
        {
            try
            {
                string cmdText = "SELECT * FROM [dbo].[Function]";
                return DBHelper.ExecuteDataSet(cmdText).Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
