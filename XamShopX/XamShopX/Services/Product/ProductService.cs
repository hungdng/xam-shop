using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XamShopX.Constants;
using XamShopX.Extensions;
using XamShopX.Models;
using XamShopX.Services.Base;

namespace XamShopX.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IRequestService _requestService;

        public ProductService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<Models.Product> AddNewProductAsync(Models.Product product, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath("products");

            string uri = builder.ToString();

            return await _requestService.PostAsync(uri, product, token);
        }

        //public async Task DeleteProductAsync(string id, string token = "")
        //{
        //    UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
        //    builder.AppendToPath("products");

        //    string uri = builder.ToString();

        //    await _requestService.DeleteAsync<ObservableCollection<Models.Product>>(uri, token);
        //}

        public async Task<ObservableCollection<Models.Product>> GetProductsAsync(string categoryId, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath($"categories/{categoryId}/products");

            string uri = builder.ToString();

            var response = await _requestService.GetAsync<ObservableCollection<Models.Product>>(uri, token);
            return response;
        }

        public async Task<Models.Product> UpdateProductAsync(Models.Product product, string token = "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath("products");

            string uri = builder.ToString();

            return await _requestService.PutAsync(uri, product, token);
        }
    }
}
