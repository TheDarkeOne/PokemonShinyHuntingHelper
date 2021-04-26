using Microsoft.AspNetCore.Mvc;
using PokemonShinyHunt.Shared;
using PokemonShinyHuntAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuntController : Controller
    {
        private readonly IDataService dataService;

        public HuntController(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Hunting>> GetHunts()
        {
            return await dataService.GetHuntHistory();
        }

        [HttpGet("[action]")]
        public async Task<Hunting> GetHuntById(int id)
        {
            return await dataService.GetHuntById(id);
        }

        [HttpPost("[action]")]
        public async Task AddHunt(Hunting hunt)
        {
            var log = new Logs()
            {
                LogDate = DateTime.Now,
                LogMessage = "Added a new Hunt:" + dataService.ConvertHuntToString(hunt),
                IsActivityLog = true
            };
            await dataService.Hunt(hunt);
            await dataService.AddLog(log);
        }

        [HttpPost("[action]")]
        public async Task DeleteHunt(Hunting hunt)
        {
            var log = new Logs()
            {
                LogDate = DateTime.Now,
                LogMessage = "Deleted a Hunt:" + dataService.ConvertHuntToString(hunt),
                IsActivityLog = true
            };
            await dataService.Delete(hunt);
        }
    }
}
