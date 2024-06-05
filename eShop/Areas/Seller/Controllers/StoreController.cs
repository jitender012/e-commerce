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
        private readonly IMapper mapper;
        private readonly IStoreService storeService;
        public StoreController(IMapper mapper, IStoreService storeService)
        {
            this.mapper = mapper;
            this.storeService = storeService;
        }


        //List of all stores that belongs to a Seller
        //GET: Seller/Store/Index
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

                return View(mapper.Map<List<StoreViewModel>>(storeService.GetAllStores(sellerId)));
            }
        }

        // Retrieves and displays details of a specific store for the current seller.
        // Get: Seller/Store/Details/10
        public ActionResult Details(int id = 0)
        {
            if (id > 0)
            {
                var userid = User.Identity.GetUserId();
                var store = mapper.Map<StoreViewModel>(storeService.GetStoreById(id));
                if (store != null)
                {
                    return View(store);
                }
                return View("StoreError",null ,"Store Not Found.");
            }
            return View("StoreError", null, "Store Id is null");
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
        
        //GET: Edit Store
        public ActionResult Edit(int id)
        {
            var userid = User.Identity.GetUserId();
            var st = storeService.GetStoreById(id);
            return View(mapper.Map<StoreViewModel>(st));
        }

        //POST: Edit Store
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

        //GET: Delete store
        public ActionResult Delete(StoreViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var st = storeService.GetStoreById(model.store_id);
            return View(mapper.Map<StoreViewModel>(st));
        }

        //POST: Delete store
        [HttpPost]
        public ActionResult Delete(int id)
        {
            storeService.DeleteStore(id);
            return RedirectToAction("Index");

        }
        
        public ActionResult StoreStock(int storeId)
        {
            var userId = User.Identity.GetUserId();
            var storeStock = storeService.GetStoreById(storeId);
            return View();
        }

    }

}