using FurnitureShop.Areas.Administration.Controllers;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureShop.Areas.Customer.Data;
using FurnitureShop.Controllers;
using eShop.Business.Interfaces;
using AutoMapper;
using eShop.Domain;
using FurnitureShop.Infrastructure;

namespace FurnitureShop.Areas.Customer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserAddressService userAddressService;        
        private ApplicationUserManager _userManager;
        private readonly IMapper mapper;
        public ProfileController(IUserAddressService userAddressService, IMapper mapper)
        {
            this.userAddressService = userAddressService;
            this.mapper = mapper;
        }

        public ProfileController(ApplicationUserManager userManager)
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
        // GET: Customer/Profile
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var accountDetails = UserManager.FindById(userId);
                UserDetails userDetails = new UserDetails()
                {
                    UserName = accountDetails.UserName,
                    Email = accountDetails.Email,
                    Mobile = accountDetails.PhoneNumber,
                    EmailConfirmed = accountDetails.EmailConfirmed,
                    MobileConfirmed = accountDetails.PhoneNumberConfirmed
                };
                return View(userDetails);
            }
            else { return View("Error"); }
         
        }
        public PartialViewResult AccountDetails()
        {
            var userId = User.Identity.GetUserId();
            var accountDetails = UserManager.FindById(userId);
            UserDetails userDetails = new UserDetails()
            {
                UserName = accountDetails.UserName,
                Email = accountDetails.Email,
                Mobile = accountDetails.PhoneNumber,
                EmailConfirmed = accountDetails.EmailConfirmed,
                MobileConfirmed = accountDetails.PhoneNumberConfirmed
            };
            return PartialView("_AccountDetails", userDetails);
        }
        public PartialViewResult ManageAddress()
        {
            return PartialView("_AddressDetails");
        }
        public JsonResult GetAddresses()
        {
            var result = userAddressService.GetAllUserAddress(User.Identity.GetUserId());
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void AddAddress(UserAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.GetUserId();
                var uAddress= mapper.Map<UserAddressDomainModel>(model);
                var result = userAddressService.AddUserAddress(uAddress);
            }
        }

        [HttpPost]
        public void DeleteAddress(int Id)
        {
            if (Id > 0)
            {
                userAddressService.DeleteUserAddress(Id);
            }
        }
    }
}