using eShop.Business.Interfaces;
using FurnitureShop.Controllers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Administration.Controllers
{
    
    public class HomeController : BaseController
    {
        public HomeController(IMainCategoryService mainCategoryService) : base(mainCategoryService)
        {
        }


        // GET: Administration/Home
        public ActionResult Home()
        {           
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult GetData()
        {
            // Simulating data retrieval
            var data = "Hello, this is some dynamic data!";
            return PartialView("_Partial", data);
        }
    }
}