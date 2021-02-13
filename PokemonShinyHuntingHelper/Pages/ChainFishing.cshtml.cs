using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHuntingHelper.Data;

namespace PokemonShinyHuntingHelper.Pages
{
    public class ChainFishingModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }
        public string BaseOdds { get; set; }
        public string MaxBaseOdds { get; set; }
        public string OddsWithShinyCharm { get; set; }
        public string MaxOddsWithShinyCharm { get; set; }

        private readonly IDataService dataService;

        public ChainFishingModel(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            CurrentHunt = new Hunting();
        }
        public void OnGet()
        {
            BaseOdds = "1/4096 ~ " + $"{CurrentHunt.Odds}";
            MaxBaseOdds = "1/100 ~ " + $"{CurrentHunt.Odds * 41}";
            OddsWithShinyCharm = "1/1365 ~ " + $"{CurrentHunt.Odds * 3}";
            MaxOddsWithShinyCharm = "1/93 ~ " + $"{CurrentHunt.Odds * 43}";
        }

        public async Task<IActionResult> OnPostAsync()
        {

            CurrentHunt.Type = TypeHunt.ChainFishing;
            await dataService.Hunt(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
