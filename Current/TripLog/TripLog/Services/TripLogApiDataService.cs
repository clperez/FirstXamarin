using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public class TripLogApiDataService : BaseHttpService, ITripLogDataService
    {
        readonly Uri _baseUri;
        readonly IDictionary<string, string> _headers;

        public Task<TripLogEntry> AddEntryAsync(TripLogEntry entry)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TripLogEntry>> GetEntriesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
