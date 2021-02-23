using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHuntingHelper.Data;

namespace PokemonShinyHuntingHelper.Pages
{
    public class HuntDetailPageModel : PageModel
    {
        private readonly IDataService dataService;

        public string Hunt { get; set; }
        public int Id { get; set; }
        public Hunting ShinyHunt { get; set; }

        public HuntDetailPageModel(IDataService dataService)
        {
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public async Task OnGet(string Hunt, int Id)
        {
            this.Hunt = Hunt;
            this.Id = Id;
            ShinyHunt = await dataService.GetHuntById(Id);
        }

        public async Task<IActionResult> OnPostAsync(int Id)
        {
            ShinyHunt = await dataService.GetHuntById(Id);
            await dataService.Delete(ShinyHunt);
            return RedirectToPage("HuntHistory");
        }
    }
}
