using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface ILocationService
    {
        Task<GeoCoords> GetGeoCoordinatesAsync();
    }
}
