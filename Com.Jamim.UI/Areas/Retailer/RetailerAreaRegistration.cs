using System.Web.Mvc;

namespace Com.Jamim.UI.Areas.Retailer
{
    public class RetailerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Retailer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Retailer_default",
                "Retailer/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Com.Jamim.Controllers.Retailer" }
            );
        }
    }
}