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

namespace eShop.Business.Services.Seller_Services
{

    public class ProductImageService : IProductImageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRepository productRepository;
        private readonly ProductImageRepository productImageRepository;
        public ProductImageService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            productRepository = new ProductRepository(unitOfWork);
            productImageRepository = new ProductImageRepository(unitOfWork);
        }

        public int AddProductImage(ProductImageDomainModel data)
        {
            if (data == null)
            {
                return 0;
            }
            ProductImage productImage = new ProductImage()
            {
                ImgUrl = data.ImgUrl,
                productId = data.productId,
            };
            productImageRepository.Insert(productImage);
            return productImage.ImgId;
        }

        public bool DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public ProductImageDomainModel GetProductImageById(int? id)
        {
            throw new NotImplementedException();
        }

        public List<ProductImageDomainModel> GetProductImages()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductImage(ProductImageDomainModel data)
        {
            throw new NotImplementedException();
        }
    }
}
