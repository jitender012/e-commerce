using FurnitureShop.Areas.Administration.Data;
using FurnitureShop.Areas.Seller.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Models
{
    public class DisplayDataViewModel
    {
        public List<DisplayCategoryViewModel> DisplayCategories { get; set; }
        public List<ProductListViewModel> ProductListView { get; set; }
        public List<SearchedProducstListViewModel> SearchedProducstList { get; set; }

    }
}