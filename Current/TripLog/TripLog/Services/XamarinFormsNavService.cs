using Qwantalabs.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using TripLog.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(TripLog.Services.XamarinFormsNavService))]
namespace TripLog.Services
{
    public class XamarinFormsNavService : INavService
    {
        readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _map.Add(viewModel, view);
        }

        public INavigation XamarinFormsNav { get; set; }
        public event PropertyChangedEventHandler CanGoBackChanged;

        public bool CanGoBack =>
            XamarinFormsNav.NavigationStack != null
            && XamarinFormsNav.NavigationStack.Count > 0;

        public async Task GoBack() =>
            await this
            .If(t => t.CanGoBack)
            .DoAsync(async t => await XamarinFormsNav.PopAsync(true))
            .Do(t => OnCanGoBackChanged());


        public async Task NavigateTo<TVM>() where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));
            this.If(t => XamarinFormsNav.NavigationStack.Last().BindingContext is BaseViewModel)
                .Do(t => ((BaseViewModel)XamarinFormsNav.NavigationStack.Last().BindingContext).Init());
        }
        public async Task NavigateTo<TVM, TParameter>(TParameter parameter)
            where TVM : BaseViewModel
        {
            await NavigateToView(typeof(TVM));
            this.If(t => XamarinFormsNav.NavigationStack.Last().BindingContext is BaseViewModel<TParameter>)
                .Do(t => ((BaseViewModel<TParameter>)XamarinFormsNav.NavigationStack.Last().BindingContext).Init(parameter));
        }

        public void RemoveLastView()
        {
            if (XamarinFormsNav.NavigationStack.Count < 2) return;
            XamarinFormsNav.NavigationStack[XamarinFormsNav.NavigationStack.Count - 2]
                .Do(v => XamarinFormsNav.RemovePage(v));
        }
        public void ClearBackStack()
        {
            if (XamarinFormsNav.NavigationStack.Count < 2) return;
            Enumerable.Range(0, XamarinFormsNav.NavigationStack.Count - 2)
                .ToList()
                .ForEach(i => XamarinFormsNav.RemovePage(XamarinFormsNav.NavigationStack[i]));
        }

        [Obsolete]
        public void NavigateToUri(Uri uri)
        {
            if (uri == null) throw new ArgumentException("Invalid URI");
            Device.OpenUri(uri);
        }

        async Task NavigateToView(Type viewModelType)
        {
            var viewType = _map.Select(o => { o.TryGetValue(viewModelType, out Type v); return v; });
            viewType.If(v => v == default)
                    .Do(o => throw new ArgumentException("No view found in view mapping for " + viewModelType.FullName + "."));

            var constructor = viewType.GetConstructor(new Type[] { });
            var view = constructor.Invoke(null) as Page;
            await XamarinFormsNav.PushAsync(view, true);
        }
        void OnCanGoBackChanged() => CanGoBackChanged?.Invoke(this, new PropertyChangedEventArgs("CanGoBack"));
        // ...
    }
}
