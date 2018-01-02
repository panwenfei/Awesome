using AWE.PWF.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace AWE.PWF.WEB.Lib
{
    public partial class MasterPage : ControllerBase
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            SetMenu();
            SetNavAddress();
        }

        /// <summary>
        /// 加载菜单 == 后期可以加入角色，可通过登录的角色加载菜单
        /// </summary>
        private void SetMenu()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = SystemSettingManager.GetFunctionList();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Select("ParaentID='00000000-0000-0000-0000-000000000000'", "ParentSort ASC"))
                {
                    sb.AppendFormat("<li class=\"has-sub\">");
                    sb.AppendFormat("<a href=\"javascript:void(0);\">");
                    sb.AppendFormat("<i class=\"fa {0}\" style=\"margin-right:3px;\"></i>", string.IsNullOrEmpty(dr["Icon"].ToString()) == true ? "fa-folder-o" : dr["Icon"]);
                    sb.AppendFormat("<span class=\"title\">{0}</span>", dr["FunctionName"]);
                    sb.AppendFormat("<span class=\"fa fa-caret-left\" style=\"float:right;margin-top:3px;\"></span>");
                    sb.AppendFormat("</a>");
                    sb.AppendFormat("<ul class=\"sub\">");
                    foreach (DataRow _dr in dt.Select("ParaentID='" + dr["FunctionId"] + "'", "FunctionSort ASC"))
                    {
                        sb.AppendFormat("<li>");
                        sb.AppendFormat("<a href=\"{0}\">{1}</a>", string.IsNullOrEmpty(_dr["Url"].ToString()) == true ? "javascript:void(0)" : _dr["Url"], _dr["FunctionName"]);
                        sb.AppendFormat("</li>");
                    }
                    sb.AppendFormat("</ul></li>");
                }
            }
            ViewBag.MenuItems = sb.ToString();
        }

        /// <summary>
        /// 设置导航信息
        /// </summary>
        private void SetNavAddress()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul class=\"address\">");
            sb.Append("<li>");
            sb.Append("<i class=\"fa fa-home\"></i>");
            sb.Append("<a href=\"javascript:void(0)\">首页</a>");
            sb.Append("<i class=\"fa fa-angle-right\"></i>");
            sb.Append("</li>");
            sb.Append("</ul>");


            ViewBag.NavMenu = sb.ToString();
        }
    }
}