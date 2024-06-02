using eShop.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly eShopEntities _dbContext;

        public UnitOfWork()
        {
            _dbContext = new eShopEntities();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
