using AutoMapper;
using eShop.Business.Services.Admin_Services;
using eShop.Business.Interfaces;
using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eShop.Domain;

namespace FurnitureShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class CategoryController : Controller
    {
        private readonly IMapper mapper;
        readonly ICategoryService categoryService;
        readonly IMainCategoryService mainCategoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService, IMainCategoryService mainCategoryService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.mainCategoryService = mainCategoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categoryDomainModel = categoryService.GetAllCategories();
            var categoryViewModel = mapper.Map<List<CategoryViewModel>>(categoryDomainModel);
            return View(categoryViewModel);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            List<MainCategoryDomainModel> mainCategory = mainCategoryService.GetAllMainCategories();
            var mainCategoryViewModel = mapper.Map<List<MainCategoryViewModel>>(mainCategory);
            ViewBag.CategoryList = new SelectList(mainCategoryViewModel, "MainCategoryId", "MainCategoryName");
            return View();
        }

        // POST: Category/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ImageFile, CategoryViewModel category)
        {
            List<MainCategoryDomainModel> mainCategory = mainCategoryService.GetAllMainCategories();
            var mainCategoryViewModel = mapper.Map<List<MainCategoryViewModel>>(mainCategory);
            ViewBag.CategoryList = new SelectList(mainCategoryViewModel, "MainCategoryId", "MainCategoryName");

            string fileName = null;

            if (category.ImageFile != null)
            {
                fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
                string extension = Path.GetExtension(category.ImageFile.FileName);

                //generate unique file name
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                //specify the path where you want to save the image
                category.category_img = "~/Images/CategoryImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/CategoryImages/"), fileName);
            }

            CategoryDomainModel categoryDomainModel = mapper.Map<CategoryDomainModel>(category);


            if (ModelState.IsValid)
            {
                int id = categoryService.AddCategory(categoryDomainModel, fileName);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Category Added!";
                }
                return RedirectToAction("Index");
            }
            return View(category);
        }



        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            List<MainCategoryDomainModel> mainCategory = mainCategoryService.GetAllMainCategories();
            var mainCategoryViewModel = mapper.Map<List<MainCategoryViewModel>>(mainCategory);
            ViewBag.CategoryList = new SelectList(mainCategoryViewModel, "MainCategoryId", "MainCategoryName");
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bcategory = categoryService.GetCategoryById(id);
            var category = new UpdateCategoryViewModel()
            {
                category_id = bcategory.category_id,
                category_name = bcategory.category_name,
                category_img = bcategory.category_img,
                mainCategoryId = bcategory.mainCategoryId,

            };

            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateCategoryViewModel category)
        {
            List<MainCategoryDomainModel> mainCategory = mainCategoryService.GetAllMainCategories();
            var mainCategoryViewModel = mapper.Map<List<MainCategoryViewModel>>(mainCategory);
            ViewBag.CategoryList = new SelectList(mainCategoryViewModel, "MainCategoryId", "MainCategoryName");

            string fileName = null;
            if (category.ImageFile != null)
            {
                fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
                string extension = Path.GetExtension(category.ImageFile.FileName);

                //generate unique file name
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                //specify the path where you want to save the image
                category.category_img = "~/Images/CategoryImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/CategoryImages/"), fileName);
            }
            if (ModelState.IsValid)
            {
                var categoryDomain = mapper.Map<CategoryDomainModel>(category);
                categoryService.UpdateCategory(categoryDomain.category_id, categoryDomain, fileName);
                return RedirectToAction("Index");
            }
            return View(category);

        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = categoryService.GetCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = categoryService.DeleteCategory(id);
            if (category == false)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}