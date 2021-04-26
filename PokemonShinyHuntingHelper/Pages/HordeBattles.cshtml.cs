using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHunt.Shared;

namespace PokemonShinyHuntingHelper.Pages
{
    public class HordeBattlesModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }
        public string BaseOdds { get; set; }
        public string OddsWithShinyCharm { get; set; }

        private readonly APIService apiService;

        public HordeBattlesModel(APIService apiService)
        {
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));

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
            await apiService.AddHuntAsync(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
