using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProducts(
            int pageNumber = 1,
            int pageSize = 10,
            string? search = null)
        {
            var products = await _productService.GetAllProductsAsync(pageNumber, pageSize);

            if (!string.IsNullOrEmpty(search))
            {
                products = products
                    .Where(p => p.Name!.Contains(search, StringComparison.OrdinalIgnoreCase)
                             || p.Category!.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var created = await _productService.AddProductAsync(product);

            return CreatedAtAction(nameof(GetProduct),
                new { id = created.Id }, created);
        }

        // PUT: api/Product
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var updated = await _productService.UpdateProductAsync(product);

            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);

            if (deleted == null)
                return NotFound();

            return Ok(deleted);
        }
    }
}
