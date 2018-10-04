using Prism.Mvvm;
using Prism.Navigation;

namespace XamShopX.ViewModels.Base
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        private bool _isBusy;
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                SetProperty(ref _isBusy, value);
            }
        }

        protected INavigationService NavigationService { get; }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }
    }
}
