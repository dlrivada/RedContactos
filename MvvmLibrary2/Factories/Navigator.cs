using System;
using System.Threading.Tasks;
using MvvmLibrary2.ViewModel.Base;
using Xamarin.Forms;

namespace MvvmLibrary2.Factories
{
    class Navigator : INavigator
    {
        private readonly Lazy<INavigation> _navigation;
        private readonly IViewFactory _viewFactory;
        public INavigation Navigation => _navigation.Value;

        public Navigator(Lazy<INavigation> navigation, IViewFactory viewFactory)
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
        }

        public async Task<IViewModel> PopAsync() => (await Navigation.PopAsync()).BindingContext as IViewModel;

        public async Task<IViewModel> PopModalAsync() => (await Navigation.PopModalAsync()).BindingContext as IViewModel;

        public async Task PopToRootAsync() => await Navigation.PopToRootAsync().ConfigureAwait(false);

        public Task<TViewModel> PushAsync<TViewModel>() where TViewModel : class, IViewModel => PushAsync((Action<TViewModel>) null);

        public async Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> action) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            Page vista = _viewFactory.Resolve(out viewModel, action);
            if (Navigation != null)
                await Navigation.PushAsync(vista).ConfigureAwait(false);
            return viewModel;            
        }

        public async Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            Page vista = _viewFactory.Resolve(out viewModel);
            if (Navigation != null)
                await Navigation.PushAsync(vista).ConfigureAwait(false);
            return viewModel;
        }

        public async Task<TViewModel> PushModalAsync<TViewModel>() where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            Page vista = _viewFactory.Resolve(out viewModel);
            if (Navigation != null)
                await Navigation.PushModalAsync(vista).ConfigureAwait(false);
            return viewModel;
        }

        public async Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            Page vista = _viewFactory.Resolve(out viewModel, action);
            if (Navigation != null)
                await Navigation.PushModalAsync(vista).ConfigureAwait(false);
            return viewModel;
        }

        public async Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            Page vista = _viewFactory.Resolve(out viewModel);
            if (Navigation != null)
                await Navigation.PushModalAsync(vista).ConfigureAwait(false);
            return viewModel;
        }
    }
}