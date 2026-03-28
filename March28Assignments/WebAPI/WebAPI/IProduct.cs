using WebAPI.Models;

namespace WebAPI
{
    public interface IProduct
    {
        Task<List<Product>> GetAllProductsAsync(int pageNumber, int pageSize);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<Product?> DeleteProductAsync(int id);
    }
}
