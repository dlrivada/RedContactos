using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmLibrary2.ViewModel.Base
{
    public class ViewModelBase : IViewModel
    {
        private bool _isBusy;
        private double _opacity;
        private bool _enabled;

        public event PropertyChangedEventHandler PropertyChanged;
        public string Titulo { get; set; }

        public ViewModelBase()
        {
            IsBusy = false;
            Opacity = 1;
            Enabled = true;
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                Opacity = value ? 0.5 : 1;
                Enabled = !value;
                SetProperty(ref _isBusy, value);
            }
        }

        public double Opacity
        {
            get { return _opacity; }
            set { SetProperty(ref _opacity, value); }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { SetProperty(ref _enabled, value); }
        }

        protected virtual bool SetProperty<T>(ref T variable, T valor, [CallerMemberName] string nombre = null)
        {
            if (Equals(variable, valor))
                return false;
            variable = valor;
#pragma warning disable S3236 // Methods with caller info attributes should not be invoked with explicit arguments
            OnPropertyChanged(nombre);
#pragma warning restore S3236 // Methods with caller info attributes should not be invoked with explicit arguments
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string nombre = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }


        public void SetState<T>(Action<T> action) where T : class, IViewModel => action?.Invoke(this as T);
    }
}