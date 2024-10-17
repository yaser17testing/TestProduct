using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using TestProduct.Data;
using TestProduct.Models;

namespace TestProduct.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly TestDbContext testDbContext;

        public ProductRepository(TestDbContext testDbContext)
        {
            this.testDbContext = testDbContext;
        }

        public async Task<Product> CreateAsync(Product Product)
        {
            await testDbContext.Products.AddAsync(Product);
            await testDbContext.SaveChangesAsync();

            return Product;

        }

        public async Task<Product?> DeleteAsync(Guid id)
        {

            var existingProduct = await testDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existingProduct == null)
            {

                return null;
            }
            testDbContext.Products.Remove(existingProduct);

            await testDbContext.SaveChangesAsync();

            return existingProduct;




        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await testDbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await testDbContext.Products.FirstOrDefaultAsync(x=> x.ProductId == id);
        }

        public async Task<Product?> UpdateAsync(Guid id, Product product)
        {


            var existingProduct = await testDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existingProduct == null)
            {

                return null;
            }
            existingProduct.ProductTitle = product.ProductTitle;
            existingProduct.Description = product.Description;

            await testDbContext.SaveChangesAsync();

            return existingProduct;



        }
    }
}
