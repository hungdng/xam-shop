using System;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamShopX.Services.Base;
using XamShopX.Services.Category;
using XamShopX.Services.Product;
using XamShopX.ViewModels.Category;
using XamShopX.ViewModels.Product;
using XamShopX.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamShopX
{
    public partial class App
    {
        public App()
        {
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }
        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("Navigation/Categories");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.Register<IRequestService, RequestService>();
            containerRegistry.Register<ICategoryService, CategoryService>();
            containerRegistry.Register<IProductService, ProductService>();
            containerRegistry.RegisterForNavigation<CategoriesPage, CategoriesPageViewModel>("Categories");
            containerRegistry.RegisterForNavigation<ProductsPage, ProductsPageViewModel>("Products");
            containerRegistry.RegisterForNavigation<EditProductPage, EditProductPageViewModel>("Edit");
        }
    }
}
