using TestProduct.Models;

namespace TestProduct.Repositories
{
    public interface IProduct
    {


        Task<List<Product>> GetAllAsync();
        Task<Product> CreateAsync(Product Product);




        Task<Product?> UpdateAsync(Guid id, Product product);

        Task<Product?> GetByIdAsync(Guid id);

        Task<Product?> DeleteAsync(Guid id);


    }
}
