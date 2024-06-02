using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Seller.Data
{
    public class ProductImageViewModel
    {
        public int ImgId { get; set; }
        public string ImgUrl { get; set; }
        public int productId { get; set; }
    }
}