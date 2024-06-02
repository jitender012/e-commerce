using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace eShop.Domain
{
    public class CategoryDomainModel
    {
        public int mainCategoryId { get; set; }
        [Key]
        [Display(Name = "Category ID")]
        public int category_id { get; set; }
        [Display(Name = "Category Name")]
        public string category_name { get; set; }
        [Display(Name = "Select Image")]
        public string category_img { get; set; }

        [Display(Name = "Main Category")]
        public string mainCategoryName { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
