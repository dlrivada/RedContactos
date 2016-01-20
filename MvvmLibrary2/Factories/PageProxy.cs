using System;
using Xamarin.Forms;

namespace MvvmLibrary2.Factories
{
    class PageProxy : IPage
    {
        private readonly Func<Page> _page;

        public PageProxy(Func<Page> page)
        {
            _page = page;
        }
        public INavigation Navigation => _page().Navigation;
    }
}