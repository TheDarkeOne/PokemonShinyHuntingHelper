using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonShinyHunt.Shared;

namespace PokemonShinyHuntingHelper.Pages
{
    public class HuntHistoryModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Hunting> HuntHistoryList { get; set; }

        private readonly APIService apiService;

        public HuntHistoryModel(APIService apiService)
        {
            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            HuntHistoryList = new List<Hunting>();
        }
        public async Task OnGet()
        {
            HuntHistoryList = await apiService.GetHuntListAsync();
        }


    }
}
