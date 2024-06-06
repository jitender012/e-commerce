using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Business.Services.Admin_Services;
using eShop.Business.Services.Seller_Services;
using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Seller.Data;
using FurnitureShop.Infrastructure;
using FurnitureShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IMainCategoryService mainCategoryService;
        private readonly ICategoryService categoryService;
        private readonly IProductImageService productImageService;
        private readonly IMapper mapper;
        private readonly IUserAddressService userAddressService;
        public HomeController(IProductService productService, IMainCategoryService mainCategoryService, ICategoryService categoryService, IProductImageService productImageService, IMapper mapper, IUserAddressService userAddressService)
        {
            this.productService = productService;
            this.mainCategoryService = mainCategoryService;
            this.categoryService = categoryService;
            this.productImageService = productImageService;
            this.mapper = mapper;
            this.userAddressService = userAddressService;
        }

        public void DisplayNavCategories()
        {
            var mainCategories = mainCategoryService.GetAllMainCategories();
            var categories = categoryService.GetAllCategories();

            List<DisplayCategoryViewModel> displayCategoryViewModels = mainCategories.Select(z => new DisplayCategoryViewModel()
            {
                mainCategoryName = z.MainCategoryName,
                mainCategoryImage = z.MainCategoryImage,
                subCategory = categories.Where(x => x.mainCategoryId == z.MainCategoryId).Select(c => new SubCategoryViewModel()
                {
                    subCatId = c.category_id,
                    subCatName = c.category_name
                }).ToList()
            }).ToList();
            ViewBag.NavCategories = displayCategoryViewModels;
        }

        // GET: Customer/Home
        public ActionResult Home()
        {
            DisplayNavCategories();
            return View();
        }

        public ActionResult AllProducts()
        {
            var ProductDetails = productService.GetProducts();
            return View(ProductDetails);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        
        public ActionResult Product(int? id)
        {
            DisplayNavCategories();
            if (!id.HasValue)
            {
                return View("Error");
            }
            var product = productService.GetProductById(id);
            var productImages = productImageService.GetProductImages(id.Value);

            ProductDetailsViewModel productDetails = new ProductDetailsViewModel()
            {
                product_id = product.product_id,
                product_name = product.product_name,
                url = product.url,

                categoryName = product.category_id.ToString(),
                brandName = product.brand_id.ToString(),
                
                ProductImages = productImages.Select(x => new ProductImageViewModel()
                {
                    ImgId = x.ImgId,
                    ImgUrl = x.ImgUrl,
                    productId = x.productId
                }).ToList()
            };
            if (product == null)
            {
                return View("Error404");
            }
            
            return View(productDetails);
        }

        //Search Products By Product Name or Description
        public ActionResult Search(string searchWord)
        {
            DisplayNavCategories();
            if (searchWord != null)
            {
                searchWord.ToLower();

                var products = productService.GetProducts(searchWord, null);
                if (products != null)
                {
                    var productsVM = mapper.Map<List<ProductViewModel>>(products);
                    return View(productsVM);
                }
            }
            var result = productService.GetProducts();
            return View(result);
        }

        //Search Products By Category
        public ActionResult FilterByCategory(int? categoryId)
        {
            DisplayNavCategories();
            if (categoryId.HasValue && categoryId > 0)
            {
                var products = productService.GetProducts(categoryId.Value);
                var productsVM = mapper.Map<List<ProductViewModel>>(products);
                return View("Search", productsVM);
            }
            else return View("Search");
        }
    }
}