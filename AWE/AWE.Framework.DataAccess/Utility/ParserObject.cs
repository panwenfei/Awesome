using AWE.Framework.Common;
using AWE.Framework.Common.Attributes;
using AWE.Framework.Common.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.DataAccess.Utility
{
    internal sealed class ParserObject
    {
        private object m_targeObject;
        private Type m_targetType;
        private string m_tableName;
        private string m_cmdText;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="targetType"></param>
        internal ParserObject(object targeObject)
        {
            m_targeObject = targeObject;
            m_targetType = targeObject.GetType();

            object[] tableAttribute = m_targetType.GetCustomAttributes(typeof(TableAttribute), false);
            if (tableAttribute.Length > 0)
            {
                m_tableName = ((TableAttribute)tableAttribute[0]).TableName;
            }
            else
            {
                throw new Exception(m_targetType.Name + "实体中未定义TableAttribute特性");
            }
        }

        /// <summary>
        /// 返回对象类型
        /// </summary>
        internal string CommandText
        {
            get { return m_cmdText.Trim(','); }
        }

        /// <summary>
        /// 返回对象类型
        /// </summary>
        internal Type TargetType
        {
            get { return m_targetType; }
        }

        /// <summary>
        /// 获取实体特性-TableName
        /// </summary>
        internal string TableName
        {
            get { return m_tableName; }
        }

        /// <summary>
        /// 根据属性名反射获取属性
        /// </summary>
        internal PropertyInfo[] TargetProperty
        {
            get { return m_targetType.GetProperties(); }
        }

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <returns></returns>
        //internal QueryObject CovertToQueryObject()
        //{
        //    QueryObject qo = new QueryObject(m_tableName);

        //    //根据属性名反射获取属性
        //    PropertyInfo[] propertyInfo = m_targetType.GetProperties();

        //    for (int i = 0; i < propertyInfo.Length; i++)
        //    {
        //        object value = propertyInfo[i].GetValue(m_targeObject, null);
        //        if (value != null && value.ToString().Length > 0)
        //        {
        //            foreach (ColumnAttribute attr in (ColumnAttribute[])propertyInfo[i].GetCustomAttributes(typeof(ColumnAttribute), false))
        //            {
        //                if (attr.IsPrimaryKey)
        //                {
        //                    qo.AddWhereCondition(attr.FieldName, value, attr.DataType);
        //                }
        //            }
        //        }
        //    }
        //    return qo;
        //}

        /// <summary>
        /// 获取Insert字符串
        /// </summary>
        /// <returns></returns>
        internal void CovertToInsert(ref string cmdText, ref List<Parameters> sqlParms)
        {
            //根据属性名反射获取属性
            PropertyInfo[] propertyInfo = m_targetType.GetProperties();

            string property_name = "";
            string values = "";
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                property_name = propertyInfo[i].Name;
                foreach (ColumnAttribute attr in (ColumnAttribute[])propertyInfo[i].GetCustomAttributes(typeof(ColumnAttribute), false))
                {
                    //判断字段操作中是否包含Insert
                    if ((attr.OperateType & SQLOperateEnum.Insert) == SQLOperateEnum.Insert)
                    {
                        property_name = attr.FieldName;
                        //判断字段是否是自增列，如果是则不拼接到sql中
                        if (attr.IsAutoNumber == true)
                        {
                            break;
                        }
                        cmdText += property_name + ",";
                        values += "@" + property_name + ",";

                        m_cmdText += property_name + " ='" + propertyInfo[i].GetValue(m_targeObject, null) + "',";
                        //解决传入的表格格式数据流(TDS)远程过程调用(RPC)协议流不正确
                        object value = propertyInfo[i].GetValue(m_targeObject, null);
                        Parameters sqlParm = null;
                        if (attr.DataType == DataTypeEnum.String && value != null && value.ToString().Length > 4000)
                        {
                            sqlParm = new Parameters("@" + property_name, attr.DataType, -1);
                        }
                        else
                        {
                            sqlParm = new Parameters("@" + property_name, attr.DataType);
                        }
                        sqlParm.ParameterValue = propertyInfo[i].GetValue(m_targeObject, null);
                        sqlParms.Add(sqlParm);
                    }
                }
            }
            cmdText = "insert into " + m_tableName + "(" + cmdText.TrimEnd(',') + ") values (" + values.TrimEnd(',') + ")";
        }

        /// <summary>
        /// 获取Update字符串
        /// </summary>
        /// <returns></returns>
        internal void CovertToUpdate(ref string cmdText, ref List<Parameters> sqlParms)
        {
            //根据属性名反射获取属性
            PropertyInfo[] propertyInfo = m_targetType.GetProperties();

            string col_name = "";
            string where = " where 1=1";

            for (int i = 0; i < propertyInfo.Length; i++)
            {
                foreach (ColumnAttribute attr in (ColumnAttribute[])propertyInfo[i].GetCustomAttributes(typeof(ColumnAttribute), false))
                {
                    col_name = attr.FieldName;
                    if (attr.IsPrimaryKey)
                    {
                        where += " and " + col_name + " = @" + col_name;

                        Parameters sqlParm = new Parameters("@" + col_name, attr.DataType);
                        sqlParm.ParameterValue = propertyInfo[i].GetValue(m_targeObject, null);
                        sqlParms.Add(sqlParm);
                    }
                    //判断字段操作中是否包含Update
                    if ((attr.OperateType & SQLOperateEnum.Update) == SQLOperateEnum.Update)
                    {
                        cmdText += col_name + " = @" + col_name + ",";
                        m_cmdText += col_name + " ='" + propertyInfo[i].GetValue(m_targeObject, null) + "',";
                        //解决传入的表格格式数据流(TDS)远程过程调用(RPC)协议流不正确
                        object value = propertyInfo[i].GetValue(m_targeObject, null);
                        Parameters sqlParm = null;
                        if (attr.DataType == DataTypeEnum.String && value != null && value.ToString().Length > 4000)
                        {
                            sqlParm = new Parameters("@" + col_name, attr.DataType, -1);
                        }
                        else
                        {
                            sqlParm = new Parameters("@" + col_name, attr.DataType);
                        }
                        sqlParm.ParameterValue = propertyInfo[i].GetValue(m_targeObject, null);
                        sqlParms.Add(sqlParm);
                    }
                }
            }
            cmdText = "update " + m_tableName + " set " + cmdText.TrimEnd(',') + where;
        }

        /// <summary>
        /// 获取Delete字符串
        /// </summary>
        /// <returns></returns>
        internal void CovertToDelete(ref string cmdText, ref List<Parameters> sqlParms)
        {
            //根据属性名反射获取属性
            PropertyInfo[] propertyInfo = m_targetType.GetProperties();

            string col_name = "";
            string where = " where 1=1";

            for (int i = 0; i < propertyInfo.Length; i++)
            {
                foreach (ColumnAttribute attr in (ColumnAttribute[])propertyInfo[i].GetCustomAttributes(typeof(ColumnAttribute), false))
                {
                    if (attr.IsPrimaryKey)
                    {
                        col_name = attr.FieldName;
                        where += " and " + col_name + " = @" + col_name;
                        Parameters sqlParm = new Parameters("@" + col_name, attr.DataType);
                        sqlParm.ParameterValue = propertyInfo[i].GetValue(m_targeObject, null);

                        sqlParms.Add(sqlParm);
                    }
                }
            }
            cmdText = "delete " + m_tableName + where;
        }

        /// <summary>
        /// 将DataTable转为实体对象
        /// </summary>
        /// <param name="dt"></param>
        internal void ConvertDataTableToEntity(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return;

            PropertyInfo[] propertyInfo = m_targetType.GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                foreach (ColumnAttribute attr in (ColumnAttribute[])propertyInfo[i].GetCustomAttributes(typeof(ColumnAttribute), false))
                {
                    //如果table中包含此属性,并且属性值不为dbnull && (dt.Rows[0][attr.FieldName] != DBNull.Value
                    if (dt.Columns.Contains(attr.FieldName) && dt.Rows[0][attr.FieldName] != DBNull.Value)
                    {
                        ////如果属性是枚举型
                        //if (propertyInfo[i].PropertyType.IsEnum)
                        //{
                        //    propertyInfo[i].SetValue(m_targeObject, Enum.ToObject(propertyInfo[i].PropertyType, dt.Rows[0][attr.FieldName]), null);
                        //}
                        ////如果属性是泛型
                        //else if (propertyInfo[i].PropertyType.IsGenericType)
                        //{
                        //    //获取范型集合参数类型
                        //    //Type tArg0 =  propertyInfo[i].PropertyType.GetGenericArguments()[0];
                        //    //Type GenericT = propertyInfo[i].PropertyType.GetGenericTypeDefinition();
                        //}
                        //else
                        //{
                        //    propertyInfo[i].SetValue(m_targeObject, dt.Rows[0][attr.FieldName], null);
                        //}

                        //判断类型是否可控 add by zwj
                        bool isNullableValueType = propertyInfo[i].PropertyType.IsGenericType && (propertyInfo[i].PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>));
                        Type genericType = propertyInfo[i].PropertyType;
                        if (isNullableValueType)
                            genericType = propertyInfo[i].PropertyType.GetGenericArguments()[0];
                        propertyInfo[i].SetValue(m_targeObject, Convert.ChangeType(dt.Rows[0][attr.FieldName], genericType), null);
                    }
                }
            }
        }

        /// <summary>
        /// 将DataTable转换实体对象List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        internal IList<T> ConvertDataTableToEntityList<T>(DataTable dt)
        {
            IList<T> _entityList = new List<T>();

            if (dt == null || dt.Rows.Count == 0) return _entityList;

            string property_name = "";
            PropertyInfo[] propertyInfo = m_targetType.GetProperties();

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < propertyInfo.Length; i++)
                {
                    property_name = propertyInfo[i].Name;

                    //如果table中包含此属性,并且属性值不为dbnull
                    if ((dt.Columns.Contains(property_name)) && (dr[property_name] != DBNull.Value))
                    {
                        //如果属性是枚举型
                        if (propertyInfo[i].PropertyType.IsEnum)
                        {
                            propertyInfo[i].SetValue(m_targeObject, Enum.ToObject(propertyInfo[i].PropertyType, dr[property_name]), null);
                        }
                        //如果属性是泛型
                        else if (propertyInfo[i].PropertyType.IsGenericType)
                        {
                            //获取范型集合参数类型
                            //Type tArg0 =  propertyInfo[i].PropertyType.GetGenericArguments()[0];
                            //Type GenericT = propertyInfo[i].PropertyType.GetGenericTypeDefinition();
                        }
                        else
                        {
                            //数据类型的公共转换方法
                            object value = dr[property_name];
                            switch (propertyInfo[i].PropertyType.Name.ToString())
                            {
                                case "Single":
                                    value = Convert.ToSingle(dr[property_name]);
                                    break;
                                case "Int32":
                                    value = Convert.ToInt32(dr[property_name].ToString() == "" ? 0 : dr[property_name]);
                                    break;
                            }
                            propertyInfo[i].SetValue(m_targeObject, value, null);
                        }
                    }
                }
            }

            return _entityList;
        }
    }
}
