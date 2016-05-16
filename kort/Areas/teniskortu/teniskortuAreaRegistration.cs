using System.Web.Mvc;

namespace kort.Areas.teniskortu
{
    public class teniskortuAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "teniskortu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "teniskortu_default",
                "teniskortu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}