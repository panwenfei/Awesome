using AWE.Framework.Common.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.DataAccess.Utility
{
    /// <summary>
    /// 公用的转换类
    /// </summary>
    internal sealed class Converter
    {
        #region 数据库相关转换方法
        /// <summary>
        /// 获取参数方向值
        /// </summary>
        /// <param name="param">参数方向</param>
        /// <returns>方向值</returns>
        internal static ParameterDirection GetParameterDirection(ParameterDirectionEnum param)
        {
            ParameterDirection pd = ParameterDirection.Input;
            switch (param)
            {
                case ParameterDirectionEnum.Input:
                    pd = ParameterDirection.Input;
                    break;

                case ParameterDirectionEnum.InputOutput:
                    pd = ParameterDirection.InputOutput;
                    break;

                case ParameterDirectionEnum.Output:
                    pd = ParameterDirection.Output;
                    break;

                case ParameterDirectionEnum.ReturnValue:
                    pd = ParameterDirection.ReturnValue;
                    break;
            }
            return pd;
        }

        /// <summary>
        ///  获取数据的事务级别
        /// </summary>
        /// <param name="level">级别参数</param>
        /// <returns>事务级别</returns>
        internal static IsolationLevel GetIsolationLevel(IsolationLevelEnum level)
        {
            IsolationLevel ret = IsolationLevel.Serializable;

            switch (level)
            {
                case IsolationLevelEnum.Chaos:
                    ret = IsolationLevel.Chaos;
                    break;

                case IsolationLevelEnum.ReadCommitted:
                    ret = IsolationLevel.ReadCommitted;
                    break;

                case IsolationLevelEnum.ReadUncommitted:
                    ret = IsolationLevel.ReadUncommitted;
                    break;

                case IsolationLevelEnum.RepeatableRead:
                    ret = IsolationLevel.RepeatableRead;
                    break;

                case IsolationLevelEnum.Serializable:
                    ret = IsolationLevel.Serializable;
                    break;

                case IsolationLevelEnum.Unspecified:
                    ret = IsolationLevel.Unspecified;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 转换成自定义类型
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns>自定义类型</returns>
        internal static DataTypeEnum GetDataType(string typeName)
        {
            DataTypeEnum ret = DataTypeEnum.Default;

            switch (typeName)
            {
                case "System.Integer":
                    ret = DataTypeEnum.Integer;
                    break;

                case "System.Long":
                    ret = DataTypeEnum.Long;
                    break;

                case "System.Float":
                    ret = DataTypeEnum.Float;
                    break;

                case "System.Double":
                    ret = DataTypeEnum.Double;
                    break;

                case "System.Decimal":
                    ret = DataTypeEnum.Decimal;
                    break;

                case "System.String":
                    ret = DataTypeEnum.String;
                    break;

                case "System.DateTime":
                    ret = DataTypeEnum.DateTime;
                    break;

                case "System.Object":
                    ret = DataTypeEnum.Object;
                    break;
            }

            return ret;
        }

        /// <summary>
        /// 指定如何解释命令字符串
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>命令枚举</returns>
        internal static CommandType GetCommandType(CommandTypeEnum type)
        {
            CommandType ret = CommandType.Text;

            switch (type)
            {
                case CommandTypeEnum.Text:
                    ret = CommandType.Text;
                    break;

                case CommandTypeEnum.StoredProcedure:
                    ret = CommandType.StoredProcedure;
                    break;

                case CommandTypeEnum.TableDirect:
                    ret = CommandType.TableDirect;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 指定如何解释数据库的类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>类型枚举</returns>
        //internal static OleDbType GetOleDbParameterType(DataTypeEnum type)
        //{
        //    OleDbType ret = OleDbType.Integer;

        //    switch (type)
        //    {
        //        case DataTypeEnum.DateTime:
        //            ret = OleDbType.DBTimeStamp;
        //            break;

        //        case DataTypeEnum.Decimal:
        //            ret = OleDbType.Decimal;
        //            break;

        //        case DataTypeEnum.Double:
        //            ret = OleDbType.Double;
        //            break;

        //        case DataTypeEnum.Float:
        //            ret = OleDbType.Single;
        //            break;

        //        case DataTypeEnum.Integer:
        //            ret = OleDbType.Integer;
        //            break;

        //        case DataTypeEnum.Long:
        //            ret = OleDbType.Integer;
        //            break;

        //        case DataTypeEnum.Object:
        //            ret = OleDbType.Variant;
        //            break;

        //        case DataTypeEnum.String:
        //            ret = OleDbType.VarChar;
        //            break;
        //    }

        //    return ret;
        //}

        /// <summary>
        /// 指定如何解释数据库的类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>类型枚举</returns>
        internal static SqlDbType GetSqlDbParameterType(DataTypeEnum type)
        {
            SqlDbType ret = SqlDbType.VarChar;

            switch (type)
            {
                case DataTypeEnum.DateTime:
                    ret = SqlDbType.DateTime;
                    break;

                case DataTypeEnum.Decimal:
                case DataTypeEnum.Double:
                    ret = SqlDbType.Decimal;
                    break;

                case DataTypeEnum.Float:
                    ret = SqlDbType.Float;
                    break;

                case DataTypeEnum.Boolean:
                    ret = SqlDbType.Bit;
                    break;

                case DataTypeEnum.Integer:
                case DataTypeEnum.Long:
                    ret = SqlDbType.Int;
                    break;
                case DataTypeEnum.Object:
                    ret = SqlDbType.Image;
                    break;
                case DataTypeEnum.Image:
                    ret = SqlDbType.Image;
                    break;
                case DataTypeEnum.Uniqueidentifier:
                    ret = SqlDbType.UniqueIdentifier;
                    break;
                default:
                    ret = SqlDbType.VarChar;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 指定如何解释数据库的类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>类型枚举</returns>
        //internal static OracleType GetOracleParameterType(DataTypeEnum type)
        //{
        //    OracleType ret = OracleType.Int32;

        //    switch (type)
        //    {
        //        case DataTypeEnum.DateTime:
        //            ret = OracleType.DateTime;
        //            break;

        //        case DataTypeEnum.Decimal:
        //            ret = OracleType.Float;
        //            break;

        //        case DataTypeEnum.Double:
        //            ret = OracleType.Double;
        //            break;

        //        case DataTypeEnum.Float:
        //            ret = OracleType.Float;
        //            break;

        //        case DataTypeEnum.Integer:
        //            ret = OracleType.Int32;
        //            break;

        //        case DataTypeEnum.Long:
        //            ret = OracleType.Int32;
        //            break;

        //        case DataTypeEnum.Object:
        //            ret = OracleType.Blob;
        //            break;

        //        case DataTypeEnum.String:
        //            ret = OracleType.NVarChar;
        //            break;
        //    }
        //    return ret;
        //}
        #endregion
    }
}
