using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;
using System.Collections.Generic;
using System.Linq;


namespace eShop.Repository.Repositories
{
    public class MainCategoryRepository : BaseRepository<MainCategory>
    {
        eShopEntities eShopEntities;
        public MainCategoryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            eShopEntities = new eShopEntities();
        }

        public List<MainCategory> GetAllMainCategories()
        {
            var list = eShopEntities.MainCategories.ToList();
            return list;
        }
    }
}