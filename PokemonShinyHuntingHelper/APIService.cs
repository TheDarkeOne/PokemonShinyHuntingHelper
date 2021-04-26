using PokemonShinyHunt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PokemonShinyHuntingHelper
{
    public class APIService
    {
        private readonly HttpClient client;
        public APIService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Hunting>> GetHuntListAsync()
        {
                return await client.GetFromJsonAsync<IEnumerable<Hunting>>("api/hunt/gethunts");
        }

        public async Task<Hunting> GetHuntByIdAsync(int id)
        {
                var result = await client.GetFromJsonAsync<Hunting>($"api/hunt/gethuntbyid?id={id}");
                return result;

        }

        public async Task AddHuntAsync(Hunting hunt)
        {
            await client.PostAsJsonAsync("api/hunt/addhunt", hunt);
        }



        public async Task DeleteAsync(Hunting hunt)
        {
            await client.PostAsJsonAsync("api/hunt/deletehunt", hunt);
        }
    }
}
