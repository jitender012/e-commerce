using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eShop.Domain
{
    public class ProductDomainModel
    {
        public int? product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        public int brand_id { get; set; }
        public int category_id { get; set; }
        public int main_category_id { get; set; }
        public decimal list_price { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? modified_date { get; set; }
        public string user_id { get; set; }
        public bool isActive { get; set; }
        public decimal selling_price { get; set; }

        public ProductImageDomainModel productImage { get; set; }
        public IEnumerable<HttpPostedFileBase> ImageFile { get; set; }
    }
}
