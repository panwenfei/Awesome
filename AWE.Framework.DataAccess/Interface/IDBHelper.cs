using AWE.Framework.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.DataAccess.Interface
{
    public interface IDBHelper
    {
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <returns>第一行第一例</returns>
        object ExecuteScalar(string cmdText);

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parms">参数</param>
        /// <returns>第一行第一例</returns>
        object ExecuteScalar(string cmdText, params Parameters[] parms);

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。[2017-09-11 康良 新增]
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parms">参数</param>
        /// <returns>第一行第一例</returns>
        int ExecuteScalar(SqlTransaction trans, string cmdText);

        /// <summary>
        /// 执行增删改查语句
        /// </summary>
        /// <param name="cmdText">insert、update、delete语句</param>
        /// <returns>影响的行数</returns>
        int ExecuteNonQuery(string cmdText);

        /// <summary>
        /// 执行事务
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdText">sql</param>
        /// <returns></returns>
        int ExecuteNonQuery(SqlTransaction trans, string cmdText);

        /// <summary>
        /// 执行增删改查语句
        /// </summary>
        /// <param name="cmdText">insert、update、delete语句</param>
        /// <param name="parms">参数</param>
        /// <returns>影响的行数</returns>
        int ExecuteNonQuery(string cmdText, params Parameters[] parms);

        /// <summary>
        /// 执行事务-带参
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <param name="cmdText">sql</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        int ExecuteNonQuery(SqlTransaction trans, string cmdText, params Parameters[] parms);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="cmdText">select语句</param>
        /// <returns>SqlDataReader</returns>
        SqlDataReader ExecuteQuery(string cmdText);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="cmdText">select语句</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlDataReader</returns>
        SqlDataReader ExecuteQuery(string cmdText, params Parameters[] parms);

        /// <summary>
        /// 获取实体集,无参数
        /// </summary>
        /// <param name="cmdText">sql</param>
        /// <returns>实体集</returns>
        DataSet ExecuteDataSet(string cmdText);

        /// <summary>
        /// 获取实体集
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parms">SQL参数</param>
        /// <returns>实体集</returns>
        DataSet ExecuteDataSet(string cmdText, params Parameters[] parms);

        ///// <summary>
        ///// 获取一个实体
        ///// </summary>
        ///// <param name="cmdText">sql</param>
        ///// <returns>单个实体</returns>
        //DataTable ExecuteDataTable(string cmdText);

        ///// <summary>
        ///// 获取一个实体
        ///// </summary>
        ///// <param name="cmdText">SQL语句</param>
        ///// <param name="parms">SQL参数</param>
        ///// <returns>单个实体</returns>
        //DataTable ExecuteDataTable(string cmdText, params Parameter[] parms);

        /// <summary>
        /// 获取实体集-存储过程
        /// </summary>
        /// <param name="procName">proc名称</param>
        /// <returns>实体集</returns>
        DataSet ExecuteRunProcedure(string procName);

        /// <summary>
        ///   获取实体集-存储过程
        /// </summary>
        /// <param name="procName">proc名称</param>
        /// <param name="parms">参数</param>
        /// <returns>实体集</returns>
        DataSet ExecuteRunProcedure(string procName, params Parameters[] parms);

        /// <summary>
        ///   获取实体集-存储过程
        /// </summary>
        /// <param name="procName">proc名称</param>
        /// <param name="parms">参数</param>
        /// <returns>实体集</returns>
        DataSet ExecuteRunProcedure(out string returnValue, string procName, params Parameters[] parms);

        /// <summary>
        /// 根据实体条件，返回相应的实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        T ExecuteObjectEntity<T>(string sqlStr, params Parameters[] parms);

        /// <summary>
        /// 返回实体对象List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        IList<T> ExecuteObjectEntityList<T>(string sqlStr, params Parameters[] parms);

        /// <summary>
        /// 根据实体对象执行Insert
        /// </summary>
        /// <param name="targetObj"></param>
        /// <returns></returns>
        int Insert(object targetObj);

        /// <summary>
        /// 根据实体List，执行插入
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="listTargetObj">实体List</param>
        /// <returns>影响执行行数</returns>
        //int Insert<T>(IList<T> listTargetObj);

        /// <summary>
        /// 根据实体，执行更新
        /// </summary>
        /// <param name="targetObj">实体类型</param>
        /// <returns></returns>
        int Update(object targetObj);

        /// <summary>
        /// 根据实体List，执行更新
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="listTargetObj">实体List</param>
        /// <returns>Sql影响行数</returns>
        //int Update<T>(IList<T> listTargetObj);

        /// <summary>
        /// 根据实体，执行插入
        /// </summary>
        /// <param name="targetObj">实体类型</param>
        /// <returns></returns>
        int Delete(object targetObj);
    }
}
