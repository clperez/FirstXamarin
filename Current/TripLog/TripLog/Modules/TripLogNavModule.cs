using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TripLog.Services;
using TripLog.ViewModels;
using TripLog.Views;

namespace TripLog.Modules
{
    public class TripLogNavModule : NinjectModule
    {
        public override void Load()
        {
            var navService = new XamarinFormsNavService();

            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailPage));
            navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

            Bind<INavService>().ToMethod(x => navService).InSingletonScope();
        }
    }
}
