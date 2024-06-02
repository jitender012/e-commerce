using FurnitureShop.Areas.Administration.Data;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Administration.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BannersController : Controller
    {
        // GET: Administration/ManageBanners
        public ActionResult BannersList()
        {
            return View();
        }
        public ActionResult BannerDetails(int id)
        {
            return View();
        }

        public ActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBanner(CreateBannerViewModel model)
        {
            return View();
        }

        public ActionResult EditBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditBanner(EditBannerViewModel model)
        {
            return View();
        }
    }
}