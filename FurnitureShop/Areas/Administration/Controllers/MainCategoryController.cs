using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Domain;
using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin, Employee")]
    public class MainCategoryController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMainCategoryService mainCategoryService;
        public MainCategoryController(IMainCategoryService mainCategoryService, IMapper mapper)
        {
            this.mainCategoryService = mainCategoryService;
            this.mapper = mapper;
        }

        // GET: Category
        public ActionResult Index()
        {

            List<MainCategoryDomainModel> mainCategories = mainCategoryService.GetAllMainCategories();
            List<MainCategoryViewModel> mainCategoryViewModels = mapper.Map<List<MainCategoryViewModel>>(mainCategories);
            return View(mainCategoryViewModels);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainCategoryViewModel category)
        {
            if (category.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
                string extension = Path.GetExtension(category.ImageFile.FileName);
                fileName = $"{fileName}{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
                string filePath = $"~/Images/MainCategoryImages/{fileName}";
                category.MainCategoryImage = filePath;

                string serverPath = Server.MapPath(filePath);
                category.ImageFile.SaveAs(serverPath);
            }

            if (ModelState.IsValid)
            {
                var mainCategory = mapper.Map<MainCategoryDomainModel>(category);
                var id = mainCategoryService.AddMainCategory(mainCategory);

                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Category Added!";
                    return RedirectToAction("Index");
                }
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
            var category = mainCategoryService.GetMainCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryVM = mapper.Map<MainCategoryViewModel>(category);
            return View(categoryVM);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = mainCategoryService.GetMainCategoryById(id);

            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryVM = mapper.Map<MainCategoryViewModel>(category);
            return View(categoryVM);
        }

        //POST: Category/Edit/5      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MainCategoryViewModel category)
        {
            if (category.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
                string extension = Path.GetExtension(category.ImageFile.FileName);
                fileName = $"{fileName}{DateTime.Now:yyyyMMddHHmmssfff}{extension}";
                string filePath = $"~/Images/MainCategoryImages/{fileName}";
                category.MainCategoryImage = filePath;

                string serverPath = Server.MapPath(filePath);
                category.ImageFile.SaveAs(serverPath);
            }
            
            var mainCategory = mapper.Map<MainCategoryDomainModel>(category);
            if (ModelState.IsValid)
            {
                mainCategoryService.UpdateMainCategory(mainCategory);
                return RedirectToAction("Index");
            }
            return View(category);

        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = mainCategoryService.GetMainCategoryById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryVM = mapper.Map<MainCategoryViewModel>(category);
            return View(categoryVM);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mainCategoryService.DeleteMainCategory(id);
            return RedirectToAction("Index");
        }
    }
}