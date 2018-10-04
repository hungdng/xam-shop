using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using XamShopX.Services.Category;
using XamShopX.Services.Product;
using XamShopX.ViewModels.Base;

namespace XamShopX.ViewModels.Product
{
    public class EditProductPageViewModel : ViewModelBase
    {
        private Models.Product _product;
        private string _title;
        private int _categorySelectedIndex;
        private List<Models.Category> _categories;
        private IProductService _productService;
        private ICategoryService _categoryService;

        public EditProductPageViewModel(INavigationService navigationService, 
            IProductService productService, ICategoryService categoryService) : base(navigationService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public ICommand SaveCommand => new DelegateCommand(SaveExecute);

        private async void SaveExecute()
        {
            if (!string.IsNullOrEmpty(Product.Id))
            {
               await _productService.UpdateProductAsync(Product);
            }
            else
            {
                await _productService.AddNewProductAsync(Product);
            }

            await NavigationService.GoBackAsync();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            // load categories
            var categories = await _categoryService.GetCategoriesAsync();
            Categories = categories.ToList();

            if (parameters.ContainsKey("id"))
            {
                try
                {
                    IsBusy = true;
                    var id = parameters["id"];
                    Title = "Edit Product";

                    var temp = _productService.GetProductByIdAsync(id.ToString());

                    Product = (await temp).Clone() as Models.Product;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[Get Product Detail] Error: {ex}");
                }

                finally
                {
                    IsBusy = false;
                }
            }
            else
            {
                Title = "New Product";
                Product = new Models.Product();
            }
        }

        #region Field
        public Models.Product Product
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public List<Models.Category> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        public int CategorySelectedIndex
        {
            get => _categorySelectedIndex;
            set
            {
                SetProperty(ref _categorySelectedIndex, value);

                if(_categorySelectedIndex > -1)
                    Product.Category = Categories[_categorySelectedIndex].Id;
            }
        }
        #endregion
    }
}
