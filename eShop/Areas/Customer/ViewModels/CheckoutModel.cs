using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Seller.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Customer.Data
{
    public class CheckoutModel
    {
        public string userName { get; set; }
        public string mobile { get; set; }
        public string email{ get; set; }
        public string address{ get; set; }
        public List<ProductViewModel> products { get; set; }
    }

}