using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Customer.Data
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Mobile { get; set; }
        public bool MobileConfirmed { get; set; }

        public UserAddressViewModel Address { get; set; }
    }

    
}