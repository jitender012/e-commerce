using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eShop.Domain
{
    public class MainCategoryDomainModel
    {
        [Key]        
        public int MainCategoryId { get; set; }
        [Required]
        public string MainCategoryName { get; set; }        
        public string MainCategoryImage { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
