using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Seller.Controllers
{
    public class StockController : Controller
    {
        // GET: Seller/Stock
        public ActionResult InventoryHome()
        {
            return View();
        }
    }
}