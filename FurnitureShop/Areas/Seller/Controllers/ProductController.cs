using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Business.Services.Admin_Services;
using eShop.Domain;
using eShop.Repository;
using eShop.Repository.Repositories;
using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Seller.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Seller.Controllers
{

    [Authorize(Roles = "Admin, Employee, Seller")]
    public class ProductController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProductService productService;
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;
        private readonly IMainCategoryService mainCategoryService;
        private readonly IProductImageService productImageService;

        public ProductController(IMapper mapper, IBrandService brand, ICategoryService category, IMainCategoryService mainCategoryService, IProductService productService, IProductImageService productImageService)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.brandService = brand;
            this.categoryService = category;
            this.mainCategoryService = mainCategoryService;
            this.productImageService = productImageService;
        }


        // GET: Administration/ManageProducts
        public ActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }


        // GET: Administration/ManageProducts/SellerProducts
        public ActionResult SellerProducts(string sellerId)
        {
            if (sellerId != null)
            {

                var products = productService.GetProducts(null, sellerId);
                var productsListVM = mapper.Map<ProductDetailsViewModel>(products);
                return View(productsListVM);
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var product = productService.GetProductById(id);
            return View(product);
        }


        private SelectList GetSelectList<TDomainModel, TViewModel>(IEnumerable<TDomainModel> domainModels, string dataValueField, string dataTextField)
        {
            var viewModelList = mapper.Map<List<TViewModel>>(domainModels);
            return new SelectList(viewModelList, dataValueField, dataTextField);
        }

        // GET: Seller/Products
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.BrandList = GetSelectList<BrandDomainModel, BrandsViewModel>(brandService.GetAllBrands(), "brand_id", "brand_name");
            ViewBag.MainCategoryList = GetSelectList<MainCategoryDomainModel, MainCategoryViewModel>(mainCategoryService.GetAllMainCategories(), "MainCategoryId", "MainCategoryName");
            ViewBag.CategoryList = GetSelectList<CategoryDomainModel, CategoryViewModel>(categoryService.GetAllCategories(), "category_id", "category_name");

            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel data)
        {
            if (ModelState.IsValid)
            {

                data.user_id = User.Identity.GetUserId();
                var product = mapper.Map<ProductDomainModel>(data);

                var pId = productService.AddProduct(product);

                if (data.ImageFile != null && data.ImageFile.Any())
                {
                    foreach (var file in data.ImageFile)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            // Generate a unique filename
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/ProductImages/"), fileName);

                            // Save the file to the server
                            file.SaveAs(path);

                            // Save image details to database (pseudo code)
                            var productImage = new ProductImageDomainModel
                            {
                                productId = pId,
                                ImgUrl = "/Images/ProductImages/" + fileName
                            };
                            productImageService.AddProductImage(productImage);
                        }
                    }
                    return RedirectToAction("Listings", User.Identity.GetUserId());
                }

                ViewBag.BrandList = GetSelectList<BrandDomainModel, BrandsViewModel>(brandService.GetAllBrands(), "brand_id", "brand_name");
                ViewBag.MainCategoryList = GetSelectList<MainCategoryDomainModel, MainCategoryViewModel>(mainCategoryService.GetAllMainCategories(), "MainCategoryId", "MainCategoryName");
                ViewBag.CategoryList = GetSelectList<CategoryDomainModel, CategoryViewModel>(categoryService.GetAllCategories(), "category_id", "category_name");
                return View(data);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(data);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var brandList = brandService.GetAllBrands();
            var mainCategoryList = mainCategoryService.GetAllMainCategories();
            var categoryList = categoryService.GetAllCategories();

            ViewBag.BrandList = new SelectList(brandList, "brand_id", "brand_name");
            ViewBag.MainCategoryList = new SelectList(mainCategoryList, "category_id", "category_name");
            ViewBag.CategoryList = new SelectList(categoryList, "category_id", "category_name");


            var product = productService.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(EditProductViewModel data, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;
                if (data.ImageFile != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
                    string extension = Path.GetExtension(data.ImageFile.FileName);
                    //generate unique file name
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    //specify the path where you want to save the image
                    data.url = "~/Images/ProductImages/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/ProductImages/"), fileName);
                }
                var product = mapper.Map<ProductDomainModel>(data);
                var isSuccess = productService.UpdateProduct(product, fileName);
                if (isSuccess)
                {
                    return RedirectToAction("Details", data.product_id);
                }
            }

            var brandList = brandService.GetAllBrands();
            var mainCategoryList = mainCategoryService.GetAllMainCategories();
            var categoryList = categoryService.GetAllCategories();

            ViewBag.BrandList = new SelectList(brandList, "brand_id", "brand_name");
            ViewBag.MainCategoryList = new SelectList(mainCategoryList, "category_id", "category_name");
            ViewBag.CategoryList = new SelectList(categoryList, "category_id", "category_name");

            return View(data);
        }


        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                productService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            return View();
        }

        public JsonResult GetCategories(int id)
        {

            var categories = categoryService.GetAllCategories(id);
            var categoriesVM = mapper.Map<List<CategoryViewModel>>(categories);
            return Json(categoriesVM, JsonRequestBehavior.AllowGet);
        }
    }

}