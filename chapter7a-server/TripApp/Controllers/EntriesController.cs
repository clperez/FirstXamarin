using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TripApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly ILogger<EntriesController> _logger;

        public EntriesController(ILogger<EntriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Entry> Get()
        {
            return Program.Entries.Values;
        }

        [HttpPost]
        public void Post(Entry entry)
        {
            Program.Entries.Add(entry.Id, entry);
        }
    }
}
