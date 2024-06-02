using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureShop.Areas.Customer.Data;


namespace FurnitureShop.Areas.Customer.Controllers
{
    public class CheckoutController : Controller
    {
        private ApplicationUserManager _userManager;        
        //private readonly CheckoutService _checkoutService;

        //public CheckoutController(CheckoutService checkoutService)
        //{           
        //    _checkoutService = checkoutService;
        //}
        public CheckoutController(ApplicationUserManager userManager)
        {
            UserManager = userManager;           
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Customer/Checkout
        //public ActionResult Checkout(int pid)
        //{
        //    ViewBag.Message = "Login first";
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = UserManager.FindById(User.Identity.GetUserId());
                

        //        //var data = _checkoutService.checkout(user, pid);
        //        return View(data);
        //    }
        //    else return RedirectToAction("Login", "Account", new { area = "" });
        //}
    }
}