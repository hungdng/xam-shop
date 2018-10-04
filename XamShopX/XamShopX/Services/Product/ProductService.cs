using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamShopX.Constants;
using XamShopX.Extensions;
using XamShopX.Services.Base;

namespace XamShopX.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IRequestService _requestService;

        //public ObservableCollection<Models.Product> Products { get; set; }

        public ProductService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task AddNewProductAsync(Models.Product product, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath("products");

            string uri = builder.ToString();

            var result =  await _requestService.PostAsync(uri, product, token);

            //Products.Add(result);
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(Models.Product product, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath($"products/{product.Id}");

            string uri = builder.ToString();

            await _requestService.DeleteAsync<ObservableCollection<Models.Product>>(uri, token);

            //Products.Remove(product);
        }

        public async Task<IEnumerable<Models.Product>> GetProductsAsync(string categoryId, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath($"categories/{categoryId}/products");

            string uri = builder.ToString();

            var products =  await _requestService.GetAsync<IEnumerable<Models.Product>>(uri, token);
           // Products = products.ToObservableCollection();

            return await Task.FromResult(products);
        }

        public async Task UpdateProductAsync(Models.Product product, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath($"products/{product.Id}");

            string uri = builder.ToString();

            var result = await _requestService.PutAsync(uri, product, token);

            //Products[Products.IndexOf(product)] = result;

            await Task.CompletedTask;
        }

        public async Task<Models.Product> GetProductByIdAsync(string productId, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath($"products/{productId}");

            string uri = builder.ToString();

            var product = await _requestService.GetAsync<Models.Product>(uri, token);
            return await Task.FromResult(product);
        }
    }
}
