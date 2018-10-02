using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using XamShopX.Models;
using XamShopX.Services.Product;
using XamShopX.ViewModels.Base;

namespace XamShopX.ViewModels.Product
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private readonly IProductService _productService;
        private ObservableCollection<Models.Product> _products;
        public ProductsPageViewModel(INavigationService navigationService, IProductService productService) : base(navigationService)
        {
            _productService = productService;

            NewCommand = new DelegateCommand(NewExcute);
            EditCommand = new DelegateCommand<Models.Product>(EditExecute);
            DeleteCommand = new DelegateCommand<string>(DeleteExcute);
        }

        private async void DeleteExcute(string id)
        {
            using (UserDialogs.Instance.Loading("Loading"))
            {
                await _productService.GetProductsAsync(id.ToString());
            }
        }

        private void EditExecute(Models.Product obj)
        {
            NavigationService.NavigateAsync("Edit", new NavigationParameters($"id={obj.Id}"));
        }

        private void NewExcute()
        {
            NavigationService.NavigateAsync("Edit");
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("id"))
            {
                var id = parameters["id"];

                if (Products != null && Products.Any())
                    return;

                using (UserDialogs.Instance.Loading("Loading"))
                {
                    Products = await _productService.GetProductsAsync(id.ToString());
                }
            }
        }

        public ICommand NewCommand {get; set;}
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        #region Field
        public ObservableCollection<Models.Product> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        #endregion
    }
}
