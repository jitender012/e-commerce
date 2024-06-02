using eShop.Business.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Controllers
{
    public class BaseController : Controller
    {        
        private readonly IMainCategoryService mainCategoryService;
      
        public BaseController(IMainCategoryService mainCategoryService)
        {
            this.mainCategoryService = mainCategoryService;           
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var navCategories = mainCategoryService.GetAllMainCategories();
            ViewBag.NavCategories = navCategories;
        }
    }

}