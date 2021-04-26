using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHunt.Shared;

namespace PokemonShinyHuntingHelper.Pages
{
    public class DexNavModel : PageModel
    {
        [BindProperty]
        public Hunting CurrentHunt { get; set; }

        private readonly APIService apiService;

        public DexNavModel(APIService apiService)
        {
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            CurrentHunt = new Hunting();
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            CurrentHunt.Type = TypeHunt.DexNav;
            await apiService.AddHuntAsync(CurrentHunt);
            return RedirectToPage("Hunts");
        }
    }
}
