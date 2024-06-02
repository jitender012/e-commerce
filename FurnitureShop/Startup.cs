using Microsoft.Owin;
using Owin;
using System.Web.Mvc;
using AutoMapper;
using FurnitureShop.Infrastructure;
[assembly: OwinStartupAttribute(typeof(FurnitureShop.Startup))]
namespace FurnitureShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperWebProfile>();
                
            });
            
            
        }

    }
}
