using System;
using System.ComponentModel;

namespace MvvmLibrary2.ViewModel.Base
{
    public interface IViewModel : INotifyPropertyChanged
    {
        string Titulo { get; set; }
        void SetState<T>(Action<T> action) where T : class, IViewModel;
    }
}