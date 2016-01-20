using System;
using MvvmLibrary2.ViewModel.Base;
using Xamarin.Forms;

namespace MvvmLibrary2.Factories
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page;
        Page Resolve<TViewModel>() where TViewModel : class, IViewModel;
        Page Resolve<TViewModel>(Action<TViewModel> action) where TViewModel : class, IViewModel;
        Page Resolve<TViewModel>(out TViewModel viewModel) where TViewModel : class, IViewModel;
        Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> action) where TViewModel : class, IViewModel;
        Page Resolve<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;
    }
}