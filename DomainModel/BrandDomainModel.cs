using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eShop.Domain
{
    public class BrandDomainModel
    {
        public int? brand_id { get; set; }
        public string brand_name { get; set; }
        public string brand_img { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
