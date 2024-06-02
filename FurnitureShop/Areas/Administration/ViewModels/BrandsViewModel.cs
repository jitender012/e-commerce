using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Administration.Data
{
    public class BrandsViewModel
    {
        public int? brand_id { get; set; }
        public string brand_name { get; set; }
        public string brand_img { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
}