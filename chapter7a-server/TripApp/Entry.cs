using System;

namespace TripApp
{
    public class Entry
    {
        public Entry()
        {
            Id = Guid.NewGuid();
        }

        public Entry(Guid guid)
        {
            Id = guid;
        }

        public Guid Id { get; private set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
        // Required for Table Storage entities
        public string PartitionKey => "ENTRY";
        public string RowKey => Id.ToString("n");
    }
}
