using eShop.Domain;
using eShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Business.Interfaces
{
    public interface IProductService
    {
        List<ProductDomainModel> GetProducts();
        List<ProductDomainModel> GetProducts(string searchQuery = null, string sellerId = null);
        List<ProductDomainModel> GetProducts(int categoryId);
        ProductDomainModel GetProductById(int? id);
        int AddProduct(ProductDomainModel data);
        bool UpdateProduct(ProductDomainModel data);
        bool DeleteProduct(int id);
    }
    public interface IStoreService
    {
        List<StoreDomainModel> GetAllStores(string sellerId = null);
        StoreDomainModel GetStoreById(int? id);
        int AddStore(StoreDomainModel data);
        bool UpdateStore(StoreDomainModel data);
        bool DeleteStore(int id);
    }

    public interface IProductImageService
    {
        List<ProductImageDomainModel> GetProductImages(int productId=0);
        ProductImageDomainModel GetProductImageById(int? id);
        int AddProductImage(ProductImageDomainModel data);
        bool UpdateProductImage(ProductImageDomainModel data);
        bool DeleteImage(int id);
    }
    public interface IStockService
    {
        int AddStock(StockDomainModel data);
        bool UpdateStock(Stock stock);
        List<StockDomainModel> GetStocks(int storeId = 0);
        StockDomainModel GetStock(int pId);
    }
}
