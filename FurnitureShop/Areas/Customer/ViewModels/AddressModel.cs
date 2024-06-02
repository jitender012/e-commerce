using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Customer.Data
{
    public class CreateAddressViewModel
    {

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PinCode { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string LandMark { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string AddressType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class  UserAddressViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PinCode { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string LandMark { get; set; }
        public string AlternatePhoneNumber { get; set; }
        [Required]
        public string AddressType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}