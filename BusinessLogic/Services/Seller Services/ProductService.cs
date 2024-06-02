using AutoMapper;
using eShop.Business.Interfaces;
using eShop.Domain;
using eShop.Repository;
using eShop.Repository.Infrastructure.Contract;
using eShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Business.Services.Seller_Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            unitOfWork = _unitOfWork;
            productRepository = new ProductRepository(unitOfWork);
            this.mapper = mapper;
        }


        public List<ProductDomainModel> GetProducts()
        {
            var products = productRepository.GetAll();
            var productsDM = mapper.Map<List<ProductDomainModel>>(products);           
            return productsDM;
        }
        public List<ProductDomainModel> GetProducts(string searchQuery = null, string sellerId = null)
        {
            if (!string.IsNullOrEmpty(sellerId))
            {
                var sellerProducts = productRepository.GetAll(p => p.user_id == sellerId);
                var sellerProductsDM = mapper.Map<List<ProductDomainModel>>(sellerProducts);  
                return sellerProductsDM;
            }
            if (searchQuery != null)
            {
                var searchedProducts = productRepository.GetAll(p => p.product_name.Contains(searchQuery) || p.description.Contains(searchQuery));
                var searchedProductsDM = mapper.Map<List<ProductDomainModel>>(searchedProducts);
                return searchedProductsDM;
            }
            else return null;

        }
        public List<ProductDomainModel> GetProducts(int categoryId)
        {
            var categoryProducts = productRepository.GetAll(p => p.category_id == categoryId);
            var categoryProductsDM = mapper.Map<List<ProductDomainModel>>(categoryProducts);
            return categoryProductsDM;
        }
        public ProductDomainModel GetProductById(int? id)
        {
            var product = productRepository.SingleOrDefault(x => x.product_id == id);
            var ProductDM = mapper.Map<ProductDomainModel>(product);
            return ProductDM;
        }
        public int AddProduct(ProductDomainModel data)
        {
            if (data == null) { return 0; }
            else
            {
                var product = mapper.Map<Product>(data);                
                product.created_date = DateTime.Now;

                var insertedProduct = productRepository.Insert(product);
                return insertedProduct.product_id;              
            }           
        }
        public bool UpdateProduct(ProductDomainModel data)
        {
            var product = productRepository.SingleOrDefault(x => x.product_id == data.product_id);
            if (product != null)
            {
                var prod = mapper.Map<Product>(data);
              
                prod.modified_date = DateTime.Now;                
                
                productRepository.UpdateProduct(prod.product_id);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteProduct(int id)
        {
            var product = productRepository.SingleOrDefault(x => x.product_id == id);
            if(product != null)
            {
                productRepository.Delete(p => p.product_id == id);
                return true;
            }
            else { return false; }
        }
    }
}
