using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ninject.Modules;
using TripLog.Android.Services;
using TripLog.Services;

namespace TripLog.Droid.Modules
{
    public class TriplogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationService>()
                      .To<LocationService>()
                      .InSingletonScope();
        }
    }
}