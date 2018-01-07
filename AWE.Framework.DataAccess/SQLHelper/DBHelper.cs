using AWE.Framework.Common;
using AWE.Framework.DataAccess.Interface;
using AWE.Framework.DataAccess.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.DataAccess.SQLHelper
{
    internal sealed class DBHelper : IDBHelper
    {
        //数据库连接对象
        private SqlConnection p_Conn = null;
        //事务对象
        private SqlTransaction p_Tran = null;
        //连接字符串
        private string p_ConnectionString = string.Empty;
        //IDisposable参数
        private bool disposed = false;
        public static int Timeout = 30;

        SqlConnection conn = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public DBHelper(string connectionString)
        {
            p_ConnectionString = connectionString;
            p_Conn = null;
            p_Tran = null;
            disposed = false;
        }

        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return p_ConnectionString; }
        }

        /// <summary>
        /// 返回打开的数据库连接对象
        /// </summary>
        /// <returns></returns>
        private SqlConnection OpenConnection()
        {
            try
            {
                conn = new SqlConnection(p_ConnectionString);
                conn.Open();
            }
            catch (Exception e)
            {
                throw e;
                //Error err = new Error(e.Message, p_ConnectionString, e);
                //ErrorHandler.ThrowTechnologyError(err);
            }
            return conn;
        }


        #region IDisposable 销毁资源

        /// <summary>
        /// 销毁资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (p_Conn != null)
                    {
                        p_Conn.Dispose();
                        p_Conn = null;
                    }

                    p_Tran = null;
                }
            }
            disposed = true;
        }

        #endregion


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>第一行第一例</returns>
        public object ExecuteScalar(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, CommandType.Text, cmdText, null);
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if ((object.Equals(obj, null)) || object.Equals(obj, System.DBNull.Value))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parms">参数</param>
        /// <returns>第一行第一例</returns>
        public object ExecuteScalar(string cmdText, params Parameters[] parms)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, CommandType.Text, cmdText, null);
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if ((object.Equals(obj, null)) || object.Equals(obj, System.DBNull.Value))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行事务 [2017-09-11 康良 新增]
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdText">sql语句</param>
        /// <returns></returns>
        public int ExecuteScalar(SqlTransaction trans, string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, CommandType.Text, cmdText, null);
            int val = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();
            return val;
        }


        /// <summary>
        /// 执行增删改查语句
        /// </summary>
        /// <param name="cmdText">insert、update、delete语句</param>
        /// <returns>影响的行数</returns>
        public int ExecuteNonQuery(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, CommandType.Text, cmdText, null);
                try
                {
                    int val = cmd.ExecuteNonQuery();
                    return val;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdText">sql语句</param>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlTransaction trans,string cmdText)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, CommandType.Text, cmdText,null);
            try
            {
                int val = cmd.ExecuteNonQuery();
                return val;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 执行增删改查语句
        /// </summary>
        /// <param name="cmdText">insert、update、delete语句</param>
        /// <param name="parms">参数</param>
        /// <returns>影响的行数</returns>
        public int ExecuteNonQuery(string cmdText, params Parameters[] parms)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn,null, CommandType.Text, cmdText, parms);
                try
                {
                    int val = cmd.ExecuteNonQuery();
                    return val;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行事务，带参
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdText">sql</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlTransaction trans, string cmdText, params Parameters[] parms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, CommandType.Text, cmdText, parms);
            try
            {
                int val = cmd.ExecuteNonQuery();
                return val;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="cmdText">select语句</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteQuery(string cmdText)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, CommandType.Text, cmdText, null);
                try
                {
                    int val = cmd.ExecuteNonQuery();
                    return cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="cmdText">select语句</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteQuery(string cmdText, params Parameters[] parms)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, CommandType.Text, cmdText, null);
                try
                {
                    int val = cmd.ExecuteNonQuery();
                    return cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 获取实体集,无参数
        /// </summary>
        /// <param name="cmdText">sql</param>
        /// <returns>实体集</returns>
        public DataSet ExecuteDataSet(string cmdText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = cmdText;
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取实体集
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns>实体集</returns>
        public DataSet ExecuteDataSet(string cmdText, params Parameters[] parms)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn,null, CommandType.Text, cmdText, parms);
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 获取实体集-存储过程
        /// </summary>
        /// <param name="procName">proc名称</param>
        /// <returns>实体集</returns>
        public DataSet ExecuteRunProcedure(string procName)
        {
            if (procName == null || procName.Length == 0)
            {
                throw new ArgumentNullException("过程名不能为空！");
            }
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procName, null);
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
            return ds;
        }

        /// <summary>
        ///   获取实体集-存储过程
        /// </summary>
        /// <param name="procName">proc名称</param>
        /// <param name="parms">参数</param>
        /// <returns>实体集</returns>
        public DataSet ExecuteRunProcedure(string procName, params Parameters[] parms)
        {
            if (procName == null || procName.Length == 0)
            {
                throw new ArgumentNullException("过程名不能为空！");
            }
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procName, parms);
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行存储过程，返回结果集
        /// </summary>
        /// <param name="returnValue">返回值</param>
        /// <param name="procName">过程名</param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public DataSet ExecuteRunProcedure(out string returnValue, string procName, params Parameters[] parms)
        {
            string obj = "";
            if (procName == null || procName.Length == 0)
            {
                throw new ArgumentNullException("过程名不能为空！");
            }
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, procName, parms);
                try
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                    }
                    foreach (SqlParameter para in cmd.Parameters)
                    {
                        if (para.Direction == ParameterDirection.Output)
                        {
                            obj = para.Value.ToString();
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
            returnValue = obj;
            return ds;
        }

        #region 实体操作

        /// <summary>
        /// 返回实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public T ExecuteObjectEntity<T>(string sqlStr, params Parameters[] parms)
        {
            try
            {
                T targetObj = Activator.CreateInstance<T>();
                ParserObject parser = new ParserObject(targetObj);
                DataTable dt = ExecuteDataSet(sqlStr, parms).Tables[0];
                parser.ConvertDataTableToEntity(dt);

                return targetObj;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回实体对象List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IList<T> ExecuteObjectEntityList<T>(string sqlStr)
        {
            try
            {
                T targetObj = Activator.CreateInstance<T>();
                ParserObject parser = new ParserObject(targetObj);
                DataTable dt = ExecuteDataSet(sqlStr).Tables[0];
                return parser.ConvertDataTableToEntityList<T>(dt);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回实体对象List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public IList<T> ExecuteObjectEntityList<T>(string sqlStr, params Parameters[] parms)
        {
            try
            {
                T targetObj = Activator.CreateInstance<T>();
                ParserObject parser = new ParserObject(targetObj);
                DataTable dt = ExecuteDataSet(sqlStr, parms).Tables[0];
                return parser.ConvertDataTableToEntityList<T>(dt);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据实体对象执行Insert
        /// </summary>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        public int Insert(object targetObj)
        {
            string cmdText = "";
            List<Parameters> parms = new List<Parameters>();
            try
            {
                ParserObject parser = new ParserObject(targetObj);
                parser.CovertToInsert(ref cmdText, ref parms);
                return ExecuteNonQuery(cmdText, parms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据实体对象List，执行Insert
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listTargetObj"></param>
        /// <returns></returns>
        //public int Insert<T>(IList<T> listTargetObj)
        //{
        //    int val = 0;
        //    try
        //    {
        //        this.BeginTransaction(IsolationLevelEnum.Default);
        //        foreach (T t in listTargetObj)
        //        {
        //            val += Insert(t);
        //        }
        //        this.Commit();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        this.Rollback();
        //        throw ex;
        //    }
        //    return val;
        //}

        /// <summary>
        /// 根据实体对象执行Update
        /// </summary>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        public int Update(object targetObj)
        {
            string cmdText = "";
            List<Parameters> sqlParms = new List<Parameters>();
            try
            {
                ParserObject parser = new ParserObject(targetObj);
                parser.CovertToUpdate(ref cmdText, ref sqlParms);
                return ExecuteNonQuery(cmdText, sqlParms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据实体对象List，执行Update
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listTargetObj"></param>
        /// <returns></returns>
        //public int Update<T>(IList<T> listTargetObj)
        //{
        //    int val = 0;
        //    try
        //    {
        //        this.BeginTransaction(IsolationLevelEnum.Default);
        //        foreach (T t in listTargetObj)
        //        {
        //            val += Update(t);
        //        }
        //        this.Commit();
        //    }
        //    catch (System.Exception ex)
        //    {
        //        this.Rollback();
        //        throw ex;
        //    }
        //    return val;
        //}

        /// <summary>
        /// 根据实体对象执行Delete
        /// </summary>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        public int Delete(object targetObj)
        {
            string cmdText = "";
            List<Parameters> sqlParms = new List<Parameters>();
            try
            {
                ParserObject parser = new ParserObject(targetObj);
                parser.CovertToDelete(ref cmdText, ref sqlParms);
                return ExecuteNonQuery(cmdText, sqlParms.ToArray());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// 初始化Command对象-SQL
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <param name="connection">SQL连接</param>
        /// <param name="commandType"SQL语句类型></param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="cmdParameters">SQL语句参数</param>
        public void PrepareCommand(SqlCommand cmd, SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] cmdParameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.Parameters.Clear();
            //遍历参数
            if (cmdParameters != null && cmdParameters.Length > 0)
            {
                foreach (SqlParameter p in cmdParameters)
                {
                    if ((p.Direction == ParameterDirection.Input || p.Direction == ParameterDirection.InputOutput) && p != null)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
            }
        }

        /// <summary>
        /// 初始化Command对象-SQL
        /// </summary>
        /// <param name="cmd">SQL命令</param>
        /// <param name="connection">SQL连接</param>
        /// <param name="transaction">事务对象</param>
        /// <param name="commandType">SQL语句类型</param>
        /// <param name="commandText">SQL语句</param>
        /// <param name="cmdParameters">SQL参数</param>
        public void PrepareCommand(SqlCommand cmd, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, Parameters[] cmdParameters)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            cmd.Connection = connection;
            cmd.CommandText = commandText;
            cmd.CommandType = commandType;
            cmd.Parameters.Clear();
            if (transaction != null)
            {
                cmd.Transaction = transaction;

                cmd.CommandType = commandType;
                cmd.CommandTimeout = Timeout;
            }
            if (cmdParameters != null && cmdParameters.Length > 0)
            {
                AttachParameters(cmd, cmdParameters);
            }
        }

        /// <summary>
        /// Parameter转换为SqlParameter
        /// </summary>
        /// <param name="p">参数</param>
        /// <returns></returns>
        public SqlParameter AttachParameters(Parameters p)
        {
            try
            {
                SqlParameter paras = new SqlParameter();
                paras.ParameterName = p.ParameterName;
                paras.Direction = Converter.GetParameterDirection(p.ParameterDirection);
                paras.SqlDbType = Converter.GetSqlDbParameterType(p.ParameterType);
                paras.Size = p.ParameterSize;
                paras.Value = p.ParameterValue;
                return paras;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 这个方法用来将命令对象和一组参数对象联系起来
        /// </summary>
        /// <param name="command">将添加参数的命令 </param>
        /// <param name="commandParameters">SQL参数 </param>
        public void AttachParameters(SqlCommand cmd, Parameters[] cmdParameters)
        {
            try
            {
                foreach (Parameters p in cmdParameters)
                {
                    if (p != null)
                    {
                        if (p.ParameterValue == null)
                        {
                            p.ParameterValue = DBNull.Value;
                        }
                        //else
                        //{
                        //    if (p.ParameterType != DataTypeEnum.Object && p.ParameterType != DataTypeEnum.Image)
                        //    {
                        //        p.ParameterValue = p.ParameterValue.ToString().Replace("'", "''");
                        //    }
                        //}
                        cmd.Parameters.Add(AttachParameters(p));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
