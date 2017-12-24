using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AWE.PWF.WEB.Lib
{
    /// <summary>
    /// 访问权限控制
    /// </summary>
    public partial class ControllerBase : Controller  
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            //bool IsOK = false;
            ////获取当前访问页面地址  
            //string requestPath = RequestHelper.GetScriptName;
            //string[] filterUrl = { //无需授权能打开的界面  
  
            //};//过滤特别页面  
            ////对上传的文件的类型进行一个个匹对  
            //for (int i = 0; i < filterUrl.Length; i++)
            //{
            //    if (requestPath == filterUrl[i])
            //    {
            //        IsOK = true;
            //        break;
            //    }
            //}
            //if (!IsOK)
            //{
            //    string UserId = RequestSession.GetSessionUser().UserId.ToString();//用户ID  
            //    DataTable dt = sys_idao.GetPermission_URL(UserId);
            //    DataView dv = new DataView(dt);
            //    dv.RowFilter = "NavigateUrl = '" + requestPath + "'";
            //    if (dv.Count == 0)
            //    {
            //        StringBuilder strHTML = new StringBuilder();
            //        strHTML.Append("<div style='text-align: center; line-height: 300px;'>");
            //        strHTML.Append("<font style=\"font-size: 13;font-weight: bold; color: red;\">权限不足</font></div>");
            //        requestContext.HttpContext.Response.Write(strHTML);
            //        requestContext.HttpContext.Response.End();
            //    }
            //}
        } 
    }
}