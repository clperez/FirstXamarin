using Ninject;
using Ninject.Modules;
using System;
using TripLog.Modules;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TripLog
{
    public partial class App : Application
    {
        public IKernel Kernel { get; set; }

        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();
            Kernel = new StandardKernel( new TripLogCoreModule(), new TripLogNavModule());
            Kernel.Load(platformModules);
            
            // NavigationPage. To get navigation components between pages
            var mainPage = new NavigationPage(new MainPage());
            mainPage.BindingContext = Kernel.Get<MainViewModel>();

            //var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;
            var navService = Kernel.Get<INavService>() as XamarinFormsNavService;
            navService.XamarinFormsNav = mainPage.Navigation;
            
            MainPage = mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
