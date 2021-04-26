using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHunt.Shared;

namespace PokemonShinyHuntingHelper.Pages
{
    public class HuntDetailPageModel : PageModel
    {
        private readonly APIService aPIService;

        public string Hunt { get; set; }
        public int Id { get; set; }
        public Hunting ShinyHunt { get; set; }

        public HuntDetailPageModel(APIService aPIService)
        {
            this.aPIService = aPIService ?? throw new ArgumentNullException(nameof(aPIService));
        }

        public async Task OnGet(string Hunt, int Id)
        {
            this.Hunt = Hunt;
            this.Id = Id;
            ShinyHunt = await aPIService.GetHuntByIdAsync(Id);
        }

        public async Task<IActionResult> OnPostAsync(int Id)
        {
            ShinyHunt = await aPIService.GetHuntByIdAsync(Id);
            await aPIService.DeleteAsync(ShinyHunt);
            return RedirectToPage("HuntHistory");
        }
    }
}
