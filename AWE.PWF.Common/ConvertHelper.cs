using AWE.Framework.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AWE.PWF.Common
{
    public class ConvertHelper<T> where T : new()
    {
        /// <summary>
        /// 将DataRow行转换成Entity
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static T ToEntity(DataRow dr)
        {
            T entity = new T();
            Type info = typeof(T);
            var members = info.GetMembers();
            foreach (var mi in members)
            {
                if (mi.MemberType == MemberTypes.Property)
                {
                    //读取属性上的DataField特性
                    object[] attributes = mi.GetCustomAttributes(typeof(ColumnAttribute), true);
                    foreach (var attr in attributes)
                    {
                        var dataFieldAttr = attr as ColumnAttribute;
                        if (dataFieldAttr != null)
                        {
                            var propInfo = info.GetProperty(mi.Name);
                            if (dr.Table.Columns.Contains(dataFieldAttr.FieldName))
                            {
                                //根据ColumnName，将dr中的相对字段赋值给Entity属性
                                propInfo.SetValue(entity,
                                                  Convert.ChangeType(dr[dataFieldAttr.FieldName], propInfo.PropertyType),
                                                  null);
                            }

                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// 将DataTable转换成Entity列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ToList(DataTable dt)
        {
            List<T> list = new List<T>(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(ToEntity(dr));
            }
            return list;
        }

        public static IList<T> ConvertToModel(DataTable dt)
        {
            try
            {
                // 定义集合    
                IList<T> ts = new List<T>();
                // 获得此模型的类型
                Type type = typeof(T);
                string tempName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    T t = new T();
                    // 获得此模型的公共属性
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;  // 检查DataTable是否包含此列    
                        if (dt.Columns.Contains(tempName))
                        {
                            // 判断此属性是否有Setter
                            if (!pi.CanWrite) continue;
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
