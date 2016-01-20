using System;
using System.Collections.Generic;
using Autofac;
using MvvmLibrary2.ViewModel.Base;
using Xamarin.Forms;

namespace MvvmLibrary2.Factories
{
    class ViewFactory : IViewFactory
    {
        readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        private readonly IComponentContext _componentContext;

        public ViewFactory(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Register<TViewModel, TView>() where TViewModel : class, IViewModel where TView : Page => _map[typeof(TViewModel)] = typeof(TView);
        public Page Resolve<TViewModel>() where TViewModel : class, IViewModel => Resolve((Action<TViewModel>) null);

        public Page Resolve<TViewModel>(Action<TViewModel> action) where TViewModel : class, IViewModel
        {
            TViewModel viewModel;
            return Resolve(out viewModel, action);
        }

        public Page Resolve<TViewModel>(out TViewModel viewModel) where TViewModel : class, IViewModel => Resolve(out viewModel, null);

        public Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> action) where TViewModel : class, IViewModel
        {
            viewModel = _componentContext.Resolve<TViewModel>();
            Type tipoVista = _map[typeof(TViewModel)];
            Page vista = _componentContext.Resolve(tipoVista) as Page;
            if (action == null)
                viewModel.SetState((Action<TViewModel>) null);

            if (vista == null)
                return null;
            vista.BindingContext = viewModel;
            return vista;
        }

        public Page Resolve<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            Type tipoVista = _map[typeof(TViewModel)];
            Page vista = _componentContext.Resolve(tipoVista) as Page;

            if (vista == null)
                return null;
            vista.BindingContext = viewModel;
            return vista;
        }
    }
}