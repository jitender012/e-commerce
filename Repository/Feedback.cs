//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eShop.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Feedback
    {
        public int feedback_id { get; set; }
        public string customer_id { get; set; }
        public int product_id { get; set; }
        public System.DateTime date { get; set; }
        public string image_url { get; set; }
        public string feedback_text { get; set; }
        public int ratingValue { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Product Product { get; set; }
    }
}