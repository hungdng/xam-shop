using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
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
        private Models.Category _categorySelectedItem;
        private List<Models.Category> _categories;
        private IProductService _productService;
        private ICategoryService _categoryService;

        public EditProductPageViewModel(INavigationService navigationService, 
            IProductService productService, ICategoryService categoryService) : base(navigationService)
        {
            _productService = productService;
            _categoryService = categoryService;

            OpenFileCommand = new DelegateCommand(OpenFileExecute);
        }

        private async void OpenFileExecute()
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking

                string fileName = fileData.FileName;
                string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);

                System.Console.WriteLine("File name chosen: " + fileName);
                System.Console.WriteLine("File data: " + contents);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }

        public ICommand SaveCommand => new DelegateCommand(SaveExecute);

        public ICommand OpenFileCommand { set; get; }



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

                    if (Product != null)
                    {
                        var category = Categories.SingleOrDefault(x => x.Id == Product.Category);
                        CategorySelectedItem = category;
                    }
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

        //public int CategorySelectedIndex
        //{
        //    get => _categorySelectedIndex;
        //    set
        //    {
        //        SetProperty(ref _categorySelectedIndex, value);

        //        if(_categorySelectedIndex > -1)
        //            Product.Category = Categories[_categorySelectedIndex].Id;
        //    }
        //}

        public Models.Category CategorySelectedItem
        {
            get => _categorySelectedItem;
            set
            {
                if (_categorySelectedItem != value)
                {
                    SetProperty(ref _categorySelectedItem, value);
                    Product.Category = _categorySelectedItem.Id;
                }
            }
        }
        #endregion
    }
}
