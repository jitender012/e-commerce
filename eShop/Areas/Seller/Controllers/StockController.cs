using eShop.Business.Interfaces;
using eShop.Domain;
using FurnitureShop.Areas.Seller.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FurnitureShop.Areas.Seller.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService stockService;
        private readonly IStoreService storeService;
        private readonly IProductService productService;

        public StockController(IStockService stockService, IStoreService storeService, IProductService productService)
        {
            this.stockService = stockService;
            this.storeService = storeService;
            this.productService = productService;   
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
                    if (stock != null && s.store_id >= 0 && s.product_id == pId)
                    {
                        storeStockEntity.qty = s.quantity.Value;
                    }
                    if (stock == null && s.product_id == pId)
                    {
                        storeStockEntity.qty = -1;
                    }
                }
                storeStock.Add(storeStockEntity);
            }
            return Json(storeStock, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public int AddStock(StockDomainModel data)
        {
            if (data != null)
            {
                return stockService.AddStock(data);
            }
            else { return 0; }
        }

        public JsonResult GetStockInStore(int storeId)
        {
            if (storeId>0)
            {
                List<InventoryDomainModel> inventories = new List<InventoryDomainModel>();
                var stocks = stockService.GetStocks(storeId);
                foreach (var item in stocks)
                {
                    var storeProduct = productService.GetProductById(item.product_id);
                    InventoryDomainModel inventory = new InventoryDomainModel();
                    inventory.product_id = item.product_id;
                    inventory.product_name = storeProduct.product_name;
                    inventory.product_desc =  storeProduct.description;
                    inventory.quantity = item.quantity.Value;
                    inventories.Add(inventory);
                }
                return Json(inventories, JsonRequestBehavior.AllowGet);
            }
            return Json("Error loading stock items.", JsonRequestBehavior.AllowGet);
        }
    }
}