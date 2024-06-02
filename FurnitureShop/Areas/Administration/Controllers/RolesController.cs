using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Controllers;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        //RoleRepository roleRepository;
        //private ApplicationRoleManager _roleManager;
        //public RolesController()
        //{
        //    roleRepository = new RoleRepository();
        //}
        //public RolesController(ApplicationRoleManager roleManager)
        //{
        //    RoleManager = roleManager;
        //}

        //public ApplicationRoleManager RoleManager
        //{
        //    get
        //    {
        //        return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        //    }
        //    private set
        //    {
        //        _roleManager = value;
        //    }
        //}
        //// GET: Administration/ManageRoles
        //[HttpGet]
        //public ActionResult Index()
        //{

        //    var roles = RoleManager.Roles.Select(x => new RoleViewModel
        //    {
        //        Id = x.Id,
        //        Name = x.Name
        //    }).ToList();
          
        //    return View(roles);
        //}
        
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(RoleViewModel obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = roleRepository.CreateRole(obj);

        //    }
        //    return View();
        //}
    }
}