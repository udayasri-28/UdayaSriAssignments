using System.Text;
using System.Text.Json;
using WebAPIMVC.Models;

namespace WebAPIMVC
{
    public class ProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Product>> GetProducts()
        {
            var response = await _client.GetAsync("api/Product");

            if (!response.IsSuccessStatusCode)
                return new List<Product>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Product>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
        }

        public async Task<Product?> GetProduct(int id)
        {
            var response = await _client.GetAsync($"api/Product/{id}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Product>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task AddProduct(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PostAsync("api/Product", content);
        }

        public async Task UpdateProduct(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _client.PutAsync("api/Product", content);
        }

        public async Task DeleteProduct(int id)
        {
            await _client.DeleteAsync($"api/Product/{id}");
        }

    }
}
