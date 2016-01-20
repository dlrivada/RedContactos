using System;
using System.Threading.Tasks;
using MvvmLibrary2.ViewModel.Base;

namespace MvvmLibrary2.Factories
{
    public interface INavigator
    {
        Task<IViewModel> PopAsync();
        Task<IViewModel> PopModalAsync();
        Task PopToRootAsync();
        Task<TViewModel> PushAsync<TViewModel>() where TViewModel: class, IViewModel;
        Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> action) where TViewModel: class, IViewModel;
        Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;
        Task<TViewModel> PushModalAsync<TViewModel>() where TViewModel : class, IViewModel;
        Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> action) where TViewModel : class, IViewModel;
        Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;
    }
}