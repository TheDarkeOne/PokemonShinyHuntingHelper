using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHuntingHelper.Data;

namespace PokemonShinyHuntingHelper.Pages
{
    public class SOSChainModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }
        public string BaseOdds { get; set; }
        public string OddsWithShinyCharm { get; set; }
        public string MaxChainOdds { get; set; }

        private readonly IDataService dataService;

        public SOSChainModel(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            CurrentHunt = new Hunting();
        }
        public void OnGet()
        {
            BaseOdds = "1/4096 ~ " + $"{CurrentHunt.Odds}";
            OddsWithShinyCharm = "1/1365 ~ " + $"{CurrentHunt.Odds * 3}%";
            MaxChainOdds = "1/273 ~ " + $"{CurrentHunt.Odds * 15}%";
        }

        public async Task<IActionResult> OnPostAsync()
        {

            CurrentHunt.Type = TypeHunt.SOSChain;
            CurrentHunt.Amount = CurrentHunt.Chain + 1;
            await dataService.Hunt(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
