using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FurnitureShop.Areas.Customer.Data;
using eShop.Business.Interfaces;
using FurnitureShop.Areas.Seller.Data;
using AutoMapper;

namespace FurnitureShop.Areas.Customer.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CheckoutController : Controller
    {
        private readonly IUserAddressService userAddressService;
        private readonly ICheckoutService checkoutService;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public CheckoutController(ICheckoutService checkoutService, IUserAddressService userAddressService, IProductService productService, IMapper mapper)
        {            
            this.checkoutService = checkoutService;
            this.userAddressService = userAddressService;
            this.productService = productService;
            this.mapper = mapper;
        }
              
        // GET: Customer/Checkout
        public ActionResult Checkout(int pid)
        {
            CheckoutModel checkout = new CheckoutModel();
            ProductViewModel product= mapper.Map<ProductViewModel>(productService.GetProductById(pid));
            UserAddressViewModel address = mapper.Map<UserAddressViewModel>(userAddressService.GetAllUserAddress(User.Identity.GetUserId()).FirstOrDefault());

            checkout.email= User.Identity.GetUserName();
            checkout.userName= User.Identity.GetUserName();
            checkout.products = new List<ProductViewModel> { product };
            checkout.address = address.Address1 + " " + address.City;
            checkout.mobile = address.PhoneNumber;
            return View(checkout);
        }
    }
}