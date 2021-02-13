using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHuntingHelper.Data;

namespace PokemonShinyHuntingHelper.Pages
{
    public class HordeBattlesModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }
        public string BaseOdds { get; set; }
        public string OddsWithShinyCharm { get; set; }

        private readonly IDataService dataService;

        public HordeBattlesModel(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

        }
        public void OnGet()
        {
            CurrentHunt = new Hunting()
            {
                Type = TypeHunt.Horde
            };
            BaseOdds = "1/819 or " + $"{CurrentHunt.Odds * 5}";
            OddsWithShinyCharm = "1/585 or " + $"{CurrentHunt.Odds * 7}";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CurrentHunt.Type = TypeHunt.Horde;
            await dataService.Hunt(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
