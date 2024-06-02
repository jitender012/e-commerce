using AutoMapper;
using eShop.Business.Interfaces;
using FurnitureShop.Areas.Seller.Data;
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

        public HomeController(IMapper mapper, IProductService productService)
        {
            this.mapper = mapper;
            this.productService = productService;
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
    }
}