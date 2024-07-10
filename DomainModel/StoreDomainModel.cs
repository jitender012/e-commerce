using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eShop.Domain
{
    public class StoreDomainModel
    {
        public int? store_id { get; set; }
        [Required]
        [Display(Name = "Store Name")]
        public string store_name { get; set; }
        [Display(Name = "Phone Number")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Street")]
        public string street { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "Zip Code")]
        public string zip_code { get; set; }
        public string user_id { get; set; }
    }
    public class StoreStockDomainModel
    {
        public int product_id { get; set; }
        public int product_name { get; set; }
        public int? store_id { get; set; }        
        public int qty { get; set; }
        public string store_name { get; set; }
        public List<StockDomainModel> stock { get; set; }
    }

}