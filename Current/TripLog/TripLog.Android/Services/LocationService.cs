using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.Android.Services
{
    public class LocationService : ILocationService
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