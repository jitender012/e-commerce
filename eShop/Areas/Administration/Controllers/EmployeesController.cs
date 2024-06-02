using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        // GET: Administration/ManageEmployees
        public ActionResult Index()
        {
            return View();
        }
    }
}