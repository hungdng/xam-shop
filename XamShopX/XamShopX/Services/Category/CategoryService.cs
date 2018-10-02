using Newtonsoft.Json;
using Plugin.Connectivity;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using XamShopX.Services.Base;
using XamShopX.Extensions;
using System.Collections.Generic;
using XamShopX.Models;
using XamShopX.Constants;

namespace XamShopX.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IRequestService _requestService;

        public CategoryService(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public async Task<ObservableCollection<Models.Category>> GetCategoriesAsync(string token= "")
        {
            UriBuilder builder = new UriBuilder(AppSettings.BaseEndpoint);
            builder.AppendToPath("Categories");

            string uri = builder.ToString();

            var response = await _requestService.GetAsync<ObservableCollection<Models.Category>>(uri, token);
            return response;
        }
    }
}
