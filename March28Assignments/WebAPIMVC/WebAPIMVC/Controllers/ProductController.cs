using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebAPIMVC.Models;

namespace WebAPIMVC.Controllers
{
    public class ProductController : Controller
    {
            private readonly HttpClient _client;

            public ProductController()
            {
                var handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                _client = new HttpClient(handler);
                _client.BaseAddress = new Uri("https://localhost:7179/");
            }

            public async Task<IActionResult> Index()
            {
                var response = await _client.GetAsync("api/Product");
                var data = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(data);
                return View(products);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(Product product)
            {
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                await _client.PostAsync("api/Product", content);
                return RedirectToAction("Index");
            }

            public async Task<IActionResult> Edit(int id)
            {
                var response = await _client.GetAsync($"api/Product/{id}");
                var data = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(data);

                return View(product);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(Product product)
            {
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                await _client.PutAsync("api/Product", content);
                return RedirectToAction("Index");
            }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.GetAsync($"api/Product/{id}");
            var data = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(data);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await _client.DeleteAsync($"api/Product/{product.Id}");
            return RedirectToAction("Index");
        }
    }

    }
