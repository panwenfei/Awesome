using AWE.Framework.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Attributes
{
    /// <summary>
    /// 表字段映射Attribute 【2017-09-20 PWF Override And Modify】
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        private bool p_IsIndex; //后加是否自增列【2017-09-19】
        private bool p_IsAutoNumber; //后加是否自增列
        private string p_FieldName;
        private DataTypeEnum p_DataType;
        private string p_FieldDescription;
        private bool p_IsPrimaryKey;
        private SQLOperateEnum p_OperateType;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段</param>
        public ColumnAttribute(string fieldName)
            : this(fieldName, false)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段</param>
        /// <param name="isPrimaryKey">主键</param>
        public ColumnAttribute(string fieldName, bool isPrimaryKey)
            : this(fieldName, isPrimaryKey, SQLOperateEnum.None)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段</param>
        /// <param name="isPrimaryKey">主键</param>
        /// <param name="operateType">操作类型</param>
        public ColumnAttribute(string fieldName, bool isPrimaryKey, SQLOperateEnum operateType)
            : this(fieldName, isPrimaryKey, false, operateType)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段</param>
        /// <param name="isPrimaryKey">主键</param>
        /// <param name="isIndex">索引</param>
        /// <param name="operateType">操作类型</param>
        public ColumnAttribute(string fieldName, bool isPrimaryKey, bool isIndex, SQLOperateEnum operateType)
            : this(fieldName, isPrimaryKey, false, isIndex, operateType)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段</param>
        /// <param name="isPrimaryKey">主键</param>
        /// <param name="isAutoNumber">自增</param>
        /// <param name="isIndex">索引</param>
        /// <param name="operateType">操作类型</param>
        public ColumnAttribute(string fieldName, bool isPrimaryKey, bool isAutoNumber, bool isIndex, SQLOperateEnum operateType)
            : this(fieldName, isPrimaryKey, isAutoNumber, isIndex, operateType, DataTypeEnum.Default)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段</param>
        /// <param name="isPrimaryKey">主键</param>
        /// <param name="isAutoNumber">自增</param>
        /// <param name="isIndex">索引</param>
        /// <param name="operateType">操作类型</param>
        /// <param name="dataType">数据类型</param>
        public ColumnAttribute(string fieldName, bool isPrimaryKey, bool isAutoNumber, bool isIndex, SQLOperateEnum operateType, DataTypeEnum dataType)
            : this(fieldName, isAutoNumber, isIndex, dataType, isPrimaryKey, "", operateType)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="isAutoNumber">是否自增</param>
        /// <param name="isIndex">是否索引</param>
        /// <param name="dataType">数据类型</param>
        /// <param name="isPrimaryKey">是否主键</param>
        /// <param name="fieldDescription">字段描述</param>
        /// <param name="operateType">数据类型</param>
        public ColumnAttribute(string fieldName, bool isAutoNumber, bool isIndex, DataTypeEnum dataType, bool isPrimaryKey, string fieldDescription, SQLOperateEnum operateType)
        {
            this.p_IsAutoNumber = isAutoNumber;
            this.p_FieldName = fieldName;
            this.p_DataType = dataType;
            this.p_IsPrimaryKey = isPrimaryKey;
            this.p_FieldDescription = fieldDescription;
            this.p_OperateType = operateType;
            this.p_IsIndex = isIndex;
        }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName
        {
            get { return this.p_FieldName; }
        }

        /// <summary>
        /// 字段数据类型
        /// </summary>
        public DataTypeEnum DataType
        {
            get { return this.p_DataType; }
        }

        /// <summary>
        /// 是否主键
        /// </summary>
        public bool IsPrimaryKey
        {
            get { return this.p_IsPrimaryKey; }
        }

        /// <summary>
        /// 字段描述
        /// </summary>
        public string FieldDescription
        {
            get { return this.p_FieldDescription; }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public SQLOperateEnum OperateType
        {
            get { return this.p_OperateType; }
        }

        /// <summary>
        /// 是否自增
        /// </summary>
        public bool IsAutoNumber
        {
            get { return this.p_IsAutoNumber; }
        }

        /// <summary>
        /// 是否索引
        /// </summary>
        public bool IsIndex
        {
            get { return this.p_IsIndex; }
        }
    }
}
