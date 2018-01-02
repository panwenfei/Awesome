using AWE.Framework.Common.Attributes;
using AWE.Framework.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWE.PWF.Entities
{
    [Table("Function")]
    public class ModelGoodsCheck
    {
        private Guid _FunctionId { get; set; }
        private string _FunctionName { get; set; }
        private string _FunctionCode { get; set; }
        private string _Description { get; set; }
        private Guid _ParaentID { get; set; }
        private string _Url { get; set; }
        private int _ParentSort { get; set; }
        private int _FunctionSort { get; set; }
        private string _Icon { get; set; }


        #region
        /// <summary>
        /// 
        /// </summary>
        [Column("FunctionId", true, true, SQLOperateEnum.Select)]
        public Guid FunctionId
        {
            get { return _FunctionId; }
            set { _FunctionId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("FunctionName", false, true, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public string FunctionName
        {
            get { return _FunctionName; }
            set { _FunctionName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("FunctionCode", false, true, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public string FunctionCode
        {
            get { return _FunctionCode; }
            set { _FunctionCode = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("Description", false, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("ParaentID", false, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public Guid ParaentID
        {
            get { return _ParaentID; }
            set { _ParaentID = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("Url", false, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("ParentSort", false, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public int ParentSort
        {
            get { return _ParentSort; }
            set { _ParentSort = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("FunctionSort", false, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public int FunctionSort
        {
            get { return _FunctionSort; }
            set { _FunctionSort = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Column("Icon", false, SQLOperateEnum.Select | SQLOperateEnum.Insert | SQLOperateEnum.Update)]
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }
        #endregion
    }
}
