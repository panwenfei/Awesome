using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.Framework.Common.Attributes
{
    /// <summary>
    /// 表映射
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        private string p_TableName;
        private string p_Description;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tableName">表名</param>
        public TableAttribute(string tableName)
            : this(tableName, "")
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="description">表描述</param>
        public TableAttribute(string tableName, string description)
        {
            this.p_TableName = tableName;
            this.p_Description = description;
        }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get { return this.p_TableName; }
        }

        /// <summary>
        /// 表描述
        /// </summary>
        public string Description
        {
            get { return this.p_Description; }
        }
    }
}
