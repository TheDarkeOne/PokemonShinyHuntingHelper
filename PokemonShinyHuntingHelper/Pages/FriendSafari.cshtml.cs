using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHunt.Shared;

namespace PokemonShinyHuntingHelper.Pages
{
    public class FriendSafariModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }
        public string BaseOdds { get; set; }
        public string OddsWithShinyCharm { get; set; }

        private readonly APIService apiService;

        public FriendSafariModel(APIService apiService)
        {
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            CurrentHunt = new Hunting();
        }
        public void OnGet()
        {
            BaseOdds = "1/819 or " + $"{CurrentHunt.Odds * 5}";
            OddsWithShinyCharm = "1/585 or " + $"{CurrentHunt.Odds * 7}";
        }

        public async Task<IActionResult> OnPostAsync()
        {

            CurrentHunt.Type = TypeHunt.FriendSafari;
            await apiService.AddHuntAsync(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
