using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace XamShopX.Services.Category
{
    public interface ICategoryService
    {
        Task<ObservableCollection<Models.Category>> GetCategoriesAsync(string token = "");
    }
}
