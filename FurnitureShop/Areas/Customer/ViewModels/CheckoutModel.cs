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
        public ProductDetailsViewModel productDetails { get; set; }
        public UserDetails userDetails { get; set; }
    }
}