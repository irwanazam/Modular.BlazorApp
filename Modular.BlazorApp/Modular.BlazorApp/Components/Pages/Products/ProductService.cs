﻿using Modular.Api.Product;
using Module.Product;

namespace Modular.BlazorApp.Components.Pages.Products
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("/api/products");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"/api/products/{id}");
        }

        public async Task AddProduct(Product product)
        {
            await _httpClient.PostAsJsonAsync("/api/products", product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _httpClient.PutAsJsonAsync($"/api/products/{product.Id}", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"/api/products/{id}");
        }
    }
}
