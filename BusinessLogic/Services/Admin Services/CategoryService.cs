using eShop.Business.Interfaces;
using eShop.Repository;
using eShop.Repository.Infrastructure.Contract;
using eShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Domain;
using AutoMapper;

namespace eShop.Business.Services.Admin_Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private CategoryRepository categoryRepository;
        public CategoryService(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            unitOfWork = _unitOfWork;
            categoryRepository = new CategoryRepository(unitOfWork);
            this.mapper = mapper;
        }
        public List<CategoryDomainModel> GetAllCategories(int mainCatId = 0)
        {
            var categories = mainCatId > 0
                ? categoryRepository.GetAll(x => x.MainCategoryId == mainCatId)
                : categoryRepository.GetAll();
            return mapper.Map<List<CategoryDomainModel>>(categories);
        }
        public int AddCategory(CategoryDomainModel category, string fileName)
        {
            category.ImageFile.SaveAs(fileName);
            Category cat = new Category()
            {
                category_name = category.category_name,
                category_img = category.category_img,
                MainCategoryId = category.mainCategoryId
            };
            var result = categoryRepository.Insert(cat);
            return result.category_id;
        }

        public CategoryDomainModel GetCategoryById(int id)
        {
            var result = categoryRepository.SingleOrDefault(c => c.category_id == id);

            CategoryDomainModel categoryDomain = new CategoryDomainModel()
            {
                category_id = result.category_id,
                category_name = result.category_name,
                category_img = result.category_img
            };
            return categoryDomain;

        }

        public bool UpdateCategory(int id, CategoryDomainModel model, string fileName)
        {

            if (fileName != null)
            {
                model.ImageFile.SaveAs(fileName);
            }
            var category = categoryRepository.SingleOrDefault(x => x.category_id == id);
            if (category != null)
            {
                category.MainCategoryId = model.mainCategoryId;
                category.category_name = model.category_name;
                category.category_img = model.category_img;
            }
            categoryRepository.Update(category);

            return true;
        }

        public bool DeleteCategory(int id)
        {

            var category = categoryRepository.SingleOrDefault(x => x.category_id == id);
            categoryRepository.Delete(x => x.category_id == id);


            return true;

        }
    }
}
