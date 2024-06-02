using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Repository.Repositories
{
    public class ProductImageRepository : BaseRepository<ProductImage>
    {
        public ProductImageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
    }
}
