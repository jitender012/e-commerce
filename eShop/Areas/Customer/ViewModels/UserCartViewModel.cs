using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Seller.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Customer.Data
{

    public class UserCartViewModel
    {
        public int cart_id { get; set; }
        public string user_id { get; set; }
        public int product_id { get; set; }
        public ProductViewModel product { get; set; }
        public UserAddressViewModel user_address { get; set; }
    }
}