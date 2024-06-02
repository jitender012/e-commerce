using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain
{
    public class UserCartDomainModel
    {
        public int cart_id { get; set; }
        public string user_id { get; set; }
        public int product_id { get; set; }
    }
}
