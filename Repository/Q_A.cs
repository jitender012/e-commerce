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
    
    public partial class Q_A
    {
        public string qus_id { get; set; }
        public string qus_text { get; set; }
        public string c_id { get; set; }
        public int p_id { get; set; }
        public System.DateTime date { get; set; }
        public string ans_text { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
