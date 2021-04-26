using Microsoft.AspNetCore.Mvc;
using PokemonShinyHunt.Shared;
using PokemonShinyHuntAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntAPI.Controllers
{
    public class LogsController : Controller
    {
        private readonly IDataService dataService;

        public LogsController(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Logs>> GetLogs()
        {
            return await dataService.GetLogs();
        }
    }
}
