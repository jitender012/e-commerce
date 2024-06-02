using eShop.Repository.Infrastructure;
using eShop.Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eShop.Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void UpdateProduct(int pId)
        {
            try
            {
                using (var context = new eShopEntities())
                {
                    var product = context.Products.FirstOrDefault(x => x.product_id == pId);
                    if (product != null)
                    {
                        product.isActive = !(product.isActive ?? false);
                        context.Entry(product).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        // Log that the product was not found
                        Console.WriteLine($"Product with id {pId} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while updating the product: {ex.Message}");
                throw; // Re-throw the exception if needed
            }
        }
    }


}
