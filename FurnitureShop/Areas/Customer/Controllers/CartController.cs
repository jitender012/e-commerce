using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Domain;
using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Customer.Data;
using FurnitureShop.Areas.Seller.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IUserAddressService userAddressService;
        private readonly IProductService _productService;
        private ApplicationUserManager _userManager;
        private readonly IMapper mapper;
        public CartController(ICartService cartService, IUserAddressService userAddressService, IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _cartService = cartService;
            this.userAddressService = userAddressService;

            this.mapper = mapper;
        }
        public CartController(ApplicationUserManager userManager)
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
        // GET: Customer/Cart
        public ActionResult Index()
        {
            var userCart = _cartService.GetUserCart(User.Identity.GetUserId());
            var data = userAddressService.GetAllUserAddress(User.Identity.GetUserId()).FirstOrDefault();
            var cartViewModel = new List<UserCartViewModel>();
            foreach (var cart in userCart)
            {
                var p = _productService.GetProductById(cart.product_id);
                var product = _productService.GetProductById(cart.product_id);
                var userCartViewModel = new UserCartViewModel
                {
                    cart_id = cart.cart_id,
                    user_id = cart.user_id,
                    product_id = cart.product_id,
                    product = new ProductViewModel
                    {
                        product_id = cart.product_id,
                        product_name = product.product_name,
                        user_id = product.user_id,
                        list_price = product.list_price,
                        brand_id = product.brand_id,
                       
                    },
                    user_address = new UserAddressViewModel
                    {
                        Address1 = data.Address1,
                        City = data.City,
                        State = data.State,
                        CreatedDate = DateTime.Now,
                        Name = data.Name,
                        PhoneNumber = data.PhoneNumber,
                        PinCode = data.PinCode,
                        LandMark = data.LandMark,
                        AddressType = data.AddressType,
                        UserId = data.UserId,
                        AlternatePhoneNumber = data.AlternatePhoneNumber,
                    }
                };
                cartViewModel.Add(userCartViewModel);
            }
            return View(cartViewModel);
        }
        public ActionResult AddToCart(int pid)
        {

            if (pid > 0)
            {
                UserCartDomainModel cart = new UserCartDomainModel()
                {
                    product_id = pid,
                    user_id = User.Identity.GetUserId(),
                };
                var result = _cartService.AddToCart(cart);
                return RedirectToAction("Index", "Cart");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}