using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Business.Services.Admin_Services;
using eShop.Domain;
using FurnitureShop.Areas.Administration.Data;
using Microsoft.AspNet.Identity;
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
    public class BrandsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBrandService brandService;
        public BrandsController(IMapper mapper, IBrandService brandService)
        {
            this.mapper = mapper;
            this.brandService = brandService;
        }
        public ActionResult GetBrands()
        {
            var brands = brandService.GetAllBrands();
            return Json(new { data = brands }, JsonRequestBehavior.AllowGet);
        }

        // GET: Administration/ManageBrands
        public ActionResult Index()
        {
            return View(mapper.Map<List<BrandsViewModel>>(brandService.GetAllBrands()));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( BrandsViewModel data, HttpPostedFileBase file = null)
        {
            if (ModelState.IsValid)
            {

                string fileName = null;
                if (data.ImageFile.FileName != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
                    string extension = Path.GetExtension(data.ImageFile.FileName);

                    //generate unique file name
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                    //specify the path where you want to save the image
                    data.brand_img = "~/Images/CategoryImages/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/CategoryImages/"), fileName);

                }

                var brandDomain = mapper.Map<BrandDomainModel>(data);
                int id = brandService.AddBrand(brandDomain, fileName);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.IsSuccess = "Branded Added!";
                }
                return RedirectToAction("Index");
            }
            return View(data);

        }
        public ActionResult Details(int id)
        {
            return View(mapper.Map<BrandsViewModel>(brandService.GetBrandById(id)));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = brandService.GetBrandById(id);
            
            return View(mapper.Map<BrandsViewModel>(result));
        }
        [HttpPost]
        public ActionResult Edit(BrandsViewModel data)
        {
            string fileName = Path.GetFileNameWithoutExtension(data.ImageFile.FileName);
            string extension = Path.GetExtension(data.ImageFile.FileName);

            //generate unique file name
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

            //specify the path where you want to save the image
            data.brand_img = "~/Images/CategoryImages/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/CategoryImages/"), fileName);
            var brandDomain = mapper.Map<BrandDomainModel>(data);
            var result = brandService.UpdateBrand(brandDomain, fileName);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var brand = brandService.GetBrandById(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);

        }

        // POST: ManageBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var brand = brandService.DeleteBrand(id);
            if (brand == false)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }
    }
}