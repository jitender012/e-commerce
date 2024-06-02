using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Controllers
{
    public class TestController : Controller
    {
        
     
        public ActionResult TestRegister()
        {
            return View();
        }
        public ActionResult TestOrders()
        {
            return View();
        }
        public ActionResult TestIndex()
        {
            return View();
        }
        public ActionResult TestAccount()
        {
            return View();
        }
        public ActionResult TestResetPassword()
        {
            return View();
        }
    }
}