using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using TripLog.ViewModels;

namespace TripLog.Modules
{
    public class TripLogCoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MainViewModel>().ToSelf();
            Bind<DetailViewModel>().ToSelf();
            Bind<NewEntryViewModel>().ToSelf();
        }
    }
}
