using System.Web.Mvc;

namespace AWE.PWF.WEB.Areas.BasicSetting
{
    public class BasicSettingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BasicSetting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BasicSetting_default",
                "BasicSetting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}