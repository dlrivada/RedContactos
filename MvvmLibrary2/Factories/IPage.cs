using Xamarin.Forms;

namespace MvvmLibrary2.Factories
{
    public interface IPage
    {
        INavigation Navigation { get; } 
    }
}