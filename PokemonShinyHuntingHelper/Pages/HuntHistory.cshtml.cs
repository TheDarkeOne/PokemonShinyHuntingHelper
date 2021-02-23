using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHuntingHelper.Data;

namespace PokemonShinyHuntingHelper.Pages
{
    public class HuntHistoryModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Hunting> HuntHistoryList { get; set; }

        private readonly IDataService dataService;

        public HuntHistoryModel(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            HuntHistoryList = new List<Hunting>();
        }
        public async Task OnGet()
        {
            HuntHistoryList = await dataService.GetHuntHistory();
        }


    }
}
