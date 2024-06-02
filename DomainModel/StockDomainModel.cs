using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain
{
    public class StockDomainModel
    {
        public int store_id { get; set; }
        public int product_id { get; set; }
        public int? quantity { get; set; }
    }
}
