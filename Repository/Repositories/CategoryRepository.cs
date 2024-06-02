using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;

namespace eShop.Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
