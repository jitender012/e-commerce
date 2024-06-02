using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Domain;
using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Seller.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Seller.Controllers
{
    public class StoreController : Controller
    {

        // GET: Store
        private readonly IMapper mapper;
        private readonly IStoreService storeService;
        public StoreController(IMapper mapper, IStoreService storeService)
        {
            this.mapper = mapper;
            this.storeService = storeService;
        }

        //Store home page
        public ActionResult StoreDashBoard(int storeId)
        {
            var userId = User.Identity.GetUserId();
            var viewModel = storeService.GetStoreById(storeId);
            if (viewModel != null)
            {

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("StoreError");
            }
        }

        public ActionResult StoreError()
        {
            return View();
        }

        public ActionResult StoreStock(int storeId)
        {
            var userId = User.Identity.GetUserId();
            var storeStock = storeService.GetStoreById(storeId);
            return View();
        }    
        public ActionResult Index()
        {
            var sellerId = User.Identity.GetUserId();
            if (Request.AcceptTypes.Contains("application/json"))
            {
                var stores = storeService.GetAllStores(sellerId);               
                return Json(stores, JsonRequestBehavior.AllowGet);
            }
            else
            {               
                if (TempData["SuccessMessage"] != null)
                {
                    ViewBag.Issuccess = TempData["SuccessMessage"];
                }
                return View();
            }
        }
       

        public ActionResult Details(int id)
        {
            var userid = User.Identity.GetUserId();
            var result = storeService.GetStoreById(id);
            return View(result);
        }

        // GET: Create store
        public ActionResult Create()
        {
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.Issuccess = TempData["SuccessMessage"];
            }
            return View();
        }

        //POST: Create store
        [HttpPost]
        public ActionResult Create(StoreViewModel data)
        {
            if (ModelState.IsValid)
            {
                var storeDomainModel = mapper.Map<StoreDomainModel>(data);
                int id = storeService.AddStore(storeDomainModel);
                if (id > 0)
                {
                    TempData["SuccessMessage"] = "Data added successfully.";
                    return RedirectToAction("Create");
                }
            }
            return View(data);
        }


        public ActionResult Edit(int id)
        {
            var userid = User.Identity.GetUserId();
            var st = storeService.GetStoreById(id);
            return View(st);
        }

        [HttpPost]
        public ActionResult Edit(StoreViewModel data)
        {
            if (ModelState.IsValid)
            {
                var storeDomainModel = mapper.Map<StoreDomainModel>(data);

                storeService.UpdateStore(storeDomainModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(StoreViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var st = storeService.GetStoreById(model.store_id);
            return View(st);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            storeService.DeleteStore(id);
            return RedirectToAction("Index");

        }


    }

}