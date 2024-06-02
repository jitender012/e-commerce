using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;


namespace eShop.Repository.Repositories
{
    public class UserRepository:BaseRepository<AspNetUser>
    {
        public UserRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {            
        }
    }
}
