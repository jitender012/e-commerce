using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;

namespace eShop.Repository.Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public BrandRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
