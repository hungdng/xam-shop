using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace XamShopX.Services.Product
{
    public interface IProductService
    {
        Task<ObservableCollection<Models.Product>> GetProductsAsync(string categoryId, string token = "");

        Task<Models.Product> AddNewProductAsync(Models.Product product, string token = "");

        Task<Models.Product> UpdateProductAsync(Models.Product product, string token = "");

        //Task DeleteProductAsync(string id, string token = "");
    }
}
