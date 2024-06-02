using eShop.Business.Interfaces;
using eShop.Domain;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Seller.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService stockService;
        private readonly IStoreService storeService;

        public StockController(IStockService stockService, IStoreService storeService)
        {
            this.stockService = stockService;
            this.storeService = storeService;
        }
        //GET: Seller/Stock
        public JsonResult AddToInventory(int pId)
        {
            List<StoreStockDomainModel> storeStock = new List<StoreStockDomainModel>();
            var stores = storeService.GetAllStores(User.Identity.GetUserId());
           
            foreach (var item in stores)
            {
                StoreStockDomainModel storeStockEntity = new StoreStockDomainModel();
                var stock = stockService.GetStocks(item.store_id.Value);
                storeStockEntity.store_id = item.store_id;
                storeStockEntity.store_name = item.store_name;
                foreach (var s in stock)
                {
                    if (stock != null && s.store_id > 0 && s.product_id==pId)
                    {
                        storeStockEntity.qty = s.quantity.Value;
                    }
                    else
                    {
                        storeStockEntity.qty = 0;
                    }
                }                               
                storeStock.Add(storeStockEntity);
            }
            return Json(storeStock, JsonRequestBehavior.AllowGet);
        }
    }
}