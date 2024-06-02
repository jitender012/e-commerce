using System.Web.Mvc;

namespace FurnitureShop.Areas.Customer
{
    public class CustomerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Customer_default",
                "Customer/{controller}/{action}/{id}",
                new {controller="Home", action = "Home", id = UrlParameter.Optional }     
            );
        }
    }
}