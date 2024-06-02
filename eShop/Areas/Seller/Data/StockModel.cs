using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Seller.Data
{
    public class StockViewModel
    {
        public int store_id { get; set; }
        public int product_id { get; set; }
        public int? quantity { get; set; }
    }   
}