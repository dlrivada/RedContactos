using Autofac;
using MvvmLibrary2.Factories;

namespace MvvmLibrary2.ModulosBase
{
    public abstract class AutofacBootstrapper
    {
        public void Run()
        {
            ContainerBuilder builder = new ContainerBuilder();
            ConfigureContainer(builder);
            IContainer container = builder.Build();
            IViewFactory viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);
            ConfigureApplication(container);
        }

        protected virtual void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<AutofacModule>();
        }

        protected abstract void RegisterViews(IViewFactory viewFactory);
        protected abstract void ConfigureApplication(IContainer container);

    }
}