using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Administration.Data
{
    public class MainCategoryViewModel
    {
        [Key]        
        public int MainCategoryId { get; set; }        
        [Required]
        public string MainCategoryName { get; set; }        
        public string MainCategoryImage { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}