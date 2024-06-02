using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Domain;
using eShop.Repository;
using eShop.Repository.Infrastructure.Contract;
using eShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Business.Services.Admin_Services
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly MainCategoryRepository mainCategoryRepository;
        private readonly IMapper mapper;
        public MainCategoryService(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            unitOfWork = _unitOfWork;
            mainCategoryRepository = new MainCategoryRepository(unitOfWork);
            this.mapper = mapper;
        }

        public int AddMainCategory(MainCategoryDomainModel data)
        {
            if (data != null)
            {
                var mainCategory = mapper.Map<MainCategory>(data);
                mainCategoryRepository.Insert(mainCategory);
                return mainCategory.MainCategoryId;
            }
            else
            {
                return 0;
            }
        }

        public bool UpdateMainCategory(MainCategoryDomainModel data)
        {
            if (data.MainCategoryId > 0)
            {
                MainCategory mainCategory = mainCategoryRepository.SingleOrDefault(x => x.MainCategoryId == data.MainCategoryId);

                if (mainCategory != null)
                {
                    mainCategory.MainCategoryName = data.MainCategoryName;
                    mainCategory.MainCategoryImage = data.MainCategoryImage;

                    mainCategoryRepository.Update(mainCategory);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteMainCategory(int id)
        {
            if (id > 0)
            {
                mainCategoryRepository.Delete(x => x.MainCategoryId == id);
                return true;
            }
            return false;
        }

        public List<MainCategoryDomainModel> GetAllMainCategories()
        {
            var result = mainCategoryRepository.GetAll();
            var mainCategories = mapper.Map<List<MainCategoryDomainModel>>(result);
            return mainCategories;
        }

        public MainCategoryDomainModel GetMainCategoryById(int id)
        {
            var result = mainCategoryRepository.SingleOrDefault(a => a.MainCategoryId == id);
            var mainCategory = mapper.Map<MainCategoryDomainModel>(result);
            return mainCategory;
        }


    }
}
