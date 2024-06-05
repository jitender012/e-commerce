using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Business.Services.Seller_Service;
using FurnitureShop.Areas.Seller.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Seller.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;
        private readonly IStoreService storeService;

        public HomeController(IMapper mapper, IProductService productService, IStoreService storeService)
        {
            this.mapper = mapper;
            this.productService = productService;
            this.storeService = storeService;
        }
        // GET: Seller/Home
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Listings(string sellerId)
        {
            if (string.IsNullOrEmpty(sellerId))
            {
                return View("Error");
            }
            else
            {
                var products = productService.GetProducts(sellerId: sellerId);
                var productsVM = mapper.Map<List<ProductViewModel>>(products);
                return View(productsVM);
            }
        }

        //Store home page
        public ActionResult StoreDashBoard(int storeId)
        {
            var userId = User.Identity.GetUserId();
            var viewModel = storeService.GetStoreById(storeId);

            if (viewModel != null)
            {
                return View(mapper.Map<StoreViewModel>(viewModel));
            }
            else
            {
                return View("StoreError",null,"Store not found.");
            }
        }
    }
}