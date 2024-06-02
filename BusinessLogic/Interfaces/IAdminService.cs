using System.Collections.Generic;
using eShop.Domain;

namespace eShop.Business.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDomainModel> GetAllCategories(int mainCatId = 0);
        CategoryDomainModel GetCategoryById(int id);


        int AddCategory(CategoryDomainModel data, string fileName);
        bool UpdateCategory(int id, CategoryDomainModel data, string fileName);
        bool DeleteCategory(int id);

    }
    public interface IMainCategoryService
    {
        List<MainCategoryDomainModel> GetAllMainCategories();
        MainCategoryDomainModel GetMainCategoryById(int id);
        int AddMainCategory(MainCategoryDomainModel data);
        bool UpdateMainCategory(MainCategoryDomainModel data);
        bool DeleteMainCategory(int id);

    }
    public interface IBannerService
    {
        List<BannerDomainModel> GetAllBanners();
        BannerDomainModel GetBannerById(int id);
        int Add(BannerDomainModel data, string fileName);
        bool UpdateBanner(BannerDomainModel data, string fileName);
        bool DeleteBanner(int id);
    }
   

    public interface IBrandService
    {
        List<BrandDomainModel> GetAllBrands();
        BrandDomainModel GetBrandById(int id);
        int AddBrand(BrandDomainModel data, string fileName);
        bool UpdateBrand(BrandDomainModel data, string fileName);
        bool DeleteBrand(int id);
    }
    
    public interface IUserService
    {
        List<UserDomainModel> GetAllUsers();
        UserDomainModel GetUserById(string id);
        string AddUser(UserDomainModel data);
        bool UpdateUser(UserDomainModel data);
        bool DeleteUser(string id);
    }
}
