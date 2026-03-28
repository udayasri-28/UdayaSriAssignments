using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI
{
        public class ProductService : IProduct
        {
            private readonly ProdContext _context;

            public ProductService(ProdContext context)
            {
                _context = context;
            }

            public async Task<Product> AddProductAsync(Product product)
            {
                await _context.product.AddAsync(product);
                await _context.SaveChangesAsync();
                return product;
            }

            public async Task<Product?> DeleteProductAsync(int id)
            {
                var product = await _context.product.FindAsync(id);
                if (product == null) return null;

                _context.product.Remove(product);
                await _context.SaveChangesAsync();
                return product;
            }

            public async Task<List<Product>> GetAllProductsAsync(int pageNumber, int pageSize)
            {
                return await _context.product
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }

            public async Task<Product?> GetProductByIdAsync(int id)
            {
                return await _context.product.FindAsync(id);
            }

            public async Task<Product?> UpdateProductAsync(Product product)
            {
                var existing = await _context.product.FindAsync(product.Id);
                if (existing == null) return null;

                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Category = product.Category;

                await _context.SaveChangesAsync();
                return existing;
            }
        }
    }
