using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using XamShopX.Services.Product;
using XamShopX.ViewModels.Base;

namespace XamShopX.ViewModels.Product
{
    public class EditProductPageViewModel : ViewModelBase
    {
        private Models.Product _product;
        private string _title;
        private IProductService _productService;

        public EditProductPageViewModel(INavigationService navigationService, IProductService productService) : base(navigationService)
        {
            _productService = productService;
        }

        public ICommand SaveCommand => new DelegateCommand(SaveExecute);

        private void SaveExecute()
        {
            if (!string.IsNullOrEmpty(Product.Id))
            {
                _productService.UpdateProductAsync(Product);
            }
            else
            {
                var respons = _productService.AddNewProductAsync(Product);
            }

            NavigationService.GoBackAsync();
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("id"))
            {
                var id = parameters["id"];
                Title = "Edit Product";

                var temp = _productService.GetProductByIdAsync(id.ToString());

                Product = (await temp).Clone() as Models.Product;
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
        #endregion
    }
}
