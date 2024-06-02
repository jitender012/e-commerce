using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Repository.Repositories
{
    public class StoreRepository : BaseRepository<Store>
    {        
        public StoreRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }       
    }
}
