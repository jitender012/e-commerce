using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;


namespace eShop.Repository.Repositories
{
    public class CartRepository : BaseRepository<UserCart>
    {        
        public CartRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }             
    }
}
