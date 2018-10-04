using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace XamShopX.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<Models.Product>> GetProductsAsync(string categoryId, string token = "");

        Task<Models.Product> GetProductByIdAsync(string productId, string token = "");

        Task AddNewProductAsync(Models.Product product, string token = "");

        Task UpdateProductAsync(Models.Product product, string token = "");

        Task DeleteProductAsync(Models.Product product, string token = "");
    }
}
