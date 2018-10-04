using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using XamShopX.Extensions;
using XamShopX.Models;
using XamShopX.Services.Category;
using XamShopX.ViewModels.Base;

namespace XamShopX.ViewModels.Category
{
    public class CategoriesPageViewModel : ViewModelBase
    {
        private readonly ICategoryService _categoryService;
        private ObservableCollection<Models.Category> _categories;

        public CategoriesPageViewModel(INavigationService navigationService, ICategoryService categoryService) : base(navigationService)
        {
            _categoryService = categoryService;

            GoToProductCommand = new DelegateCommand<Models.Category>(GoToProduct);
        }

        private void GoToProduct(Models.Category obj)
        {
            NavigationService.NavigateAsync("Products", new NavigationParameters($"id={obj.Id}"));
        }

        public ICommand GoToProductCommand { get; set; }

        #region Field
        public ObservableCollection<Models.Category> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        #endregion

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (Categories != null && Categories.Any())
                return;
            try
            {
                IsBusy = true;
                var categories = await _categoryService.GetCategoriesAsync();
                Categories = categories.ToObservableCollection();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Get Categories] Error: {ex}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
