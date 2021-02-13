using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntingHelper.Data
{
    public class HuntingChain
    {
        public int Id { get; set; }
        public int Generation { get; set; }
        public TypeHunt Type { get; set; }
        public int Chain { get; set; }
        public int DexLevel { get; set; }
        public int Amount { get; set; }
        public string Pokemon { get; set; }
        public bool ShinyCharm { get; set; }

        public HuntingChain(int Id = 0, int Generation = 6, TypeHunt Type = TypeHunt.Horde, int Chain = 0, int DexLevel = 0, int Amount = 0, string Pokemon = "None", bool ShinyCharm = false)
        {
            this.Id = Id;
            this.Generation = Generation;
            this.Type = Type;
            this.Chain = Chain;
            this.DexLevel = DexLevel;
            this.Amount = Amount;
            this.Pokemon = Pokemon;
            this.ShinyCharm = ShinyCharm;
        }

    }
}
