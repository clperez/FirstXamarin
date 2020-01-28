using System;
using System.Collections.Generic;
using System.Text;

namespace TripLog.Models
{
    public class TripLogEntry
    {
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
