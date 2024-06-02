using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureShop.Areas.Administration.Data;

namespace FurnitureShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class UsersController : Controller
    {
        private ApplicationUserManager _userManager;

        public UsersController()
        {

        }
        public UsersController(ApplicationUserManager userManager)
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


        // GET: Administration/UserList
        public ActionResult UserList()
        {            
            var users = UserManager.Users.ToList().
                Select(x => new UsersListViewModel()
            {
                Email = x.Email,
                UserName = x.UserName,
                Id = x.Id,
                Role= UserManager.GetRoles(x.Id).ToList()
            }).ToList(); 

            return View(users);
        }

        [HttpPost]
        public ActionResult UserList(string Search)
        {
            var search = Search.ToLower();
            var users = UserManager.Users.ToList().Where(m=>m.UserName.ToLower().Contains(search)).
                Select(x => new UsersListViewModel()
                {
                    Email = x.Email,
                    UserName = x.UserName,
                    Id = x.Id,
                    Role = UserManager.GetRoles(x.Id).ToList()
                }).ToList();

            return View(users);
        }
    }
}