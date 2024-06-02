using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Repository.Repositories
{
    public class UserAddressRepository : BaseRepository<Address>
    {
        public UserAddressRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
