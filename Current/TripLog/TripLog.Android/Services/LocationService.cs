using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TripLog.Models;

namespace TripLog.Droid.Services
{
    public class LocationService
    {
        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            var location = await Xamarin.Essentials.Geolocation.GetLocationAsync();
            return new GeoCoords
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };
        }
    }
}