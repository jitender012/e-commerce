using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Domain
{
    public class ProductImageDomainModel
    {
        public int ImgId { get; set; }
        public string ImgUrl { get; set; }
        public int productId { get; set; }
    }
}
