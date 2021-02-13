using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHuntingHelper.Data;

namespace PokemonShinyHuntingHelper.Pages
{
    public class SoftResetsModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }
        public string BaseOdds { get; set; }
        public string OddsWithShinyCharm { get; set; }

        private readonly IDataService dataService;

        public SoftResetsModel(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
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
            await dataService.Hunt(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
