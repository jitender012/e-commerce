using eShop.Domain;
using eShop.Repository.Infrastructure.Contract;
using eShop.Repository.Repositories;
using eShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Business.Interfaces;

namespace eShop.Business.Services.Admin_Services
{
    public class BrandService: IBrandService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly BrandRepository brandRepository;
        public BrandService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            brandRepository = new BrandRepository(unitOfWork);
        }
       
        public int AddBrand(BrandDomainModel data, string fileName)
        {
            data.ImageFile.SaveAs(fileName);
            Brand brand = new Brand()
            {
                brand_name = data.brand_name,               
                brand_img = data.brand_img
            };
            var result = brandRepository.Insert(brand);
            return result.brand_id;
        }

        public bool UpdateBrand(BrandDomainModel data, string fileName)
        {

            if (fileName != null)
            {
                data.ImageFile.SaveAs(fileName);
            }
            var brand = brandRepository.SingleOrDefault(x => x.brand_id == data.brand_id);
            if (brand != null)
            {
                brand.brand_name = data.brand_name;
                brand.brand_img = data.brand_img;
            }
            brandRepository.Update(brand);

            return true;
        }

        public bool DeleteBrand(int id)
        {
            var Brand = brandRepository.SingleOrDefault(x => x.brand_id == id);
            brandRepository.Delete(x => x.brand_id == id);
            return true;
        }

        public List<BrandDomainModel> GetAllBrands()
        {
            var brandList = brandRepository.GetAll();

            var result = new List<BrandDomainModel>();
            foreach (var item in brandList)
            {
                BrandDomainModel brandDomainModel = new BrandDomainModel()
                {
                    brand_id = item.brand_id,
                    brand_name = item.brand_name,
                    brand_img = item.brand_img,                   
                };
                result.Add(brandDomainModel);
            }
            return result;
        }

        public BrandDomainModel GetBrandById(int id)
        {
            var result = brandRepository.SingleOrDefault(c => c.brand_id == id);

            BrandDomainModel brandDomain = new BrandDomainModel()
            {
                brand_id = result.brand_id,
                brand_name = result.brand_name,
                brand_img = result.brand_img,
            };
            return brandDomain;
        }             
    }
}
