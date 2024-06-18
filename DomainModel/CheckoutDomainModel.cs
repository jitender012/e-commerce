using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain
{
    public class CheckoutDomainModel
    {

    }

    public partial class OrderItem
    {
        public int order_item_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal list_price { get; set; }
        public decimal discount { get; set; }
        public string seller_id { get; set; }
        public int order_id { get; set; }
    }
    public partial class Order
    {
        public int order_id { get; set; }
        public string customer_id { get; set; }
        public byte order_status { get; set; }
        public DateTime order_date { get; set; }
        public DateTime required_date { get; set; }
        public DateTime? shipped_date { get; set; }
    }
}
