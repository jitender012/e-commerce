using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FurnitureShop.Areas.Seller.Data;
using eShop.Domain;
using FurnitureShop.Areas.Administration.Data;

namespace FurnitureShop.Areas.Seller.Data
{    
    public class ProductViewModel
    {
        public int? product_id { get; set; }
        [Required]
        public string product_name { get; set; }
        public int brand_id { get; set; }
        public int category_id { get; set; }
        public int main_category_id { get; set; }
        public decimal list_price { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public DateTime? created_date { get; set; }
        public DateTime? modified_date { get; set; }
        public string user_id { get; set; }
        public bool isActive { get; set; }
        public decimal selling_price { get; set; }
                
        public IEnumerable<HttpPostedFileBase> ImageFile { get; set; }
        public ProductImageViewModel productImage { get; set; }
    }



    public class ProductListViewModel
    {
        public int product_id { get; set; }
        [Display(Name = "Product Name")]
        public string product_name { get; set; }

        [Display(Name = "Price")]
        public decimal list_price { get; set; }

        [Display(Name = "Image")]
        public string url { get; set; }
    }
    public class ProductAttributesViewModel
    {

        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

    }
    public class ProductListWithStockViewModel
    {

        public int product_id { get; set; }
        [Display(Name = "Product Name")]
        public string product_name { get; set; }

        [Display(Name = "Price")]
        public decimal list_price { get; set; }

        [Display(Name = "Image")]
        public string url { get; set; }
        public int? quantity { get; set; }

    }
    public class SearchedProducstListViewModel
    {

        public int product_id { get; set; }
        [Display(Name = "Product Name")]
        public string product_name { get; set; }

        [Display(Name = "Price")]
        public decimal list_price { get; set; }

        [Display(Name = "Image")]
        public string url { get; set; }

        public int? brand_id { get; set; }

        [Display(Name = "Main Category")]
        public int? mainCategoryId { get; set; }

        [Display(Name = "Category")]
        public int? category_id { get; set; }

        public string brand_name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Main Category Name")]
        public string mainCategoryName { get; set; }

        [Display(Name = "Category Name")]
        public string categoryName { get; set; }

        [Display(Name = "Brand Name")]
        public string brandName { get; set; }

    }


    public class EditProductViewModel
    {
       
        [Display(Name = "Product Id")]
        public int? product_id { get; set; }

        [Display(Name = "Product Name")]
        public string product_name { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? created_date { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? modified_date { get; set; }

        [Display(Name = "Brand")]
        public int? brand_id { get; set; }

        [Display(Name = "Main Category")]
        public int? mainCategoryId { get; set; }

        [Display(Name = "Category")]
        public int? category_id { get; set; }

        [Display(Name = "List Price")]
        public decimal list_price { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Product Image")]
        public string url { get; set; }

        [Display(Name = "Main Category Name")]
        public string mainCategoryName { get; set; }

        [Display(Name = "Category Name")]
        public string categoryName { get; set; }

        [Display(Name = "Brand Name")]
        public string brandName { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public List<ProductAttributesViewModel> AdditionalDetails { get; set; }

    }
    public class ProductDetailsViewModel
    {
    
        [Display(Name = "Product Id")]
        public int? product_id { get; set; }

        [Display(Name = "Product Name")]
        public string product_name { get; set; }

        [Display(Name = "Created Date")]
        public DateTime? created_date { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? modified_date { get; set; }

        [Display(Name = "Brand")]
        public int? brand_id { get; set; }

        [Display(Name = "Main Category")]
        public int? mainCategoryId { get; set; }

        [Display(Name = "Category")]
        public int? category_id { get; set; }

        [Display(Name = "List Price")]
        public decimal list_price { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Product Image")]
        public string url { get; set; }

        [Display(Name = "Main Category Name")]
        public string mainCategoryName { get; set; }

        [Display(Name = "Category Name")]
        public string categoryName { get; set; }

        [Display(Name = "Brand Name")]
        public string brandName { get; set; }
      

        public bool isInWishlist { get; set; }
    }
}