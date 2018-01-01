using AWE.PWF.Business;
using AWE.PWF.Common;
using AWE.PWF.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWE.PWF.WEB.Areas.BasicSetting.Controllers
{
    public class FunctionController : Controller
    {
        // GET: BasicSetting/Function
        public ActionResult List()
        {
            return View();
        }

        public ActionResult FunctionModal()
        {
            return View();
        }

        public ActionResult GetFunctionList()
        {
            try
            {
                DataTable dt = SystemSettingManager.GetFunctionList();
                if (dt.Rows.Count > 0)
                {
                    //跳过dt的前10行，取后20行  即取得11-30行
                    DataTable TakeTopList = dt.AsEnumerable().Skip((Convert.ToInt32(Request["page"]) - 1) * Convert.ToInt32(Request["limit"])).Take(Convert.ToInt32(Request["limit"])).CopyToDataTable<DataRow>();
                    return Json(new { total = dt.Rows.Count, rows = ConvertHelper<ModelGoodsCheck>.ConvertToModel(TakeTopList).ToList() }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { total = dt.Rows.Count, rows = ConvertHelper<ModelGoodsCheck>.ConvertToModel(dt).ToList() }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { total = 0, rows = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}