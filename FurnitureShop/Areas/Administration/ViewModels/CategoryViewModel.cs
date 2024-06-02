using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Administration.Data
{
    public class CategoryViewModel
    {
       
        public int mainCategoryId { get; set; }
        [Key]
        [Display(Name = "Category ID")]
        public int category_id { get; set; }
        [Display(Name = "Category Name")]
        public string category_name { get; set; }
        [Display(Name = "Select Image")]
        public string category_img { get; set; }

        [Display(Name ="Main Category")]
        public string mainCategoryName { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class CategoryListViewModel
    {
        [Key]
        [Display(Name = "Category ID")]
        public int category_id { get; set; }
        [Display(Name = "Category Name")]
        public string category_name { get; set; }
        [Display(Name = "Image")]
        public string category_img { get; set; }
        public int mainCategoryId { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class UpdateCategoryViewModel
    {
        public string MainCategoryName { get; set; }
        [Required]
        public int mainCategoryId { get; set; }
        [Key]
        [Display(Name = "Category ID")]
        public int category_id { get; set; }
        [Display(Name = "Category Name")]
        public string category_name { get; set; }
        [Display(Name = "Select Image")]
        public string category_img { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }       
    }
    public class DisplayCategoryViewModel
    {  
        public string mainCategoryName { get; set; }
        public string mainCategoryImage { get; set; }
        public List<SubCategoryViewModel> subCategory { get; set; }

    }
    public class SubCategoryViewModel
    {
        public int subCatId { get; set; }
        public string subCatName { get; set; }
    }
}