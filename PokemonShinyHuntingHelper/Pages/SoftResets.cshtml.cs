using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHunt.Shared;

namespace PokemonShinyHuntingHelper.Pages
{
    public class SoftResetsModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }
        public string BaseOdds { get; set; }
        public string OddsWithShinyCharm { get; set; }

        private readonly APIService apiService;

        public SoftResetsModel(APIService apiService)
        {
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            CurrentHunt = new Hunting();
        }
        public void OnGet()
        {
            BaseOdds = "1/4096 or " + $"{CurrentHunt.Odds}";
            OddsWithShinyCharm = "3/4096 or " + $"{CurrentHunt.Odds * 3}";
        }

        public async Task<IActionResult> OnPostAsync()
        {

            CurrentHunt.Type = TypeHunt.SoftReset;
            await apiService.AddHuntAsync(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
