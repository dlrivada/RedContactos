using Autofac;
using MvvmLibrary2.Factories;
using Xamarin.Forms;

namespace MvvmLibrary2.ModulosBase
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            //builder.Register(ctx => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}