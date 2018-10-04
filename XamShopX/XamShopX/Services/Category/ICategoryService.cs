using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace XamShopX.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<Models.Category>> GetCategoriesAsync(string token = "");
    }
}
