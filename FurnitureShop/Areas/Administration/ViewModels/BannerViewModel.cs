using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureShop.Areas.Administration.Data
{
    public class BannerViewModel
    {
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class CreateBannerViewModel
    {

        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }        
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class EditBannerViewModel
    {
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string ImagePath { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        
        public DateTime ModifiedDate { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
    public class BannersListViewModel
    {
        public int BannerId { get; set; }
        public string BannerName { get; set; }
        public string ImagePath { get; set; }
        public bool? IsActive { get; set; }      
    }
}