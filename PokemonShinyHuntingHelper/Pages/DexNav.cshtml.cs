using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHuntingHelper.Data;

namespace PokemonShinyHuntingHelper.Pages
{
    public class DexNavModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }

        private readonly IDataService dataService;

        public DexNavModel(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            CurrentHunt = new Hunting();
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CurrentHunt.Type = TypeHunt.DexNav;
            await dataService.Hunt(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
