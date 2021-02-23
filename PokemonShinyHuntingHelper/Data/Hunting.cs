using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntingHelper.Data
{
    public class Hunting
    {
        public int Id { get; set; }
        public int Generation { get; set; }
        public TypeHunt Type { get; set; }
        public int Chain { get; set; }
        public int DexLevel { get; set; }
        public int Amount { get; set; }
        public string Pokemon { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public double Odds { get; set; }
        public bool ShinyCharm { get; set; }

        public Hunting()
        {
            Id = 0;
            Generation = 6;
            Type = TypeHunt.Default;
            Chain = 0;
            DexLevel = 0;
            Amount = 0;
            Pokemon = "";
            Odds = .00024;
            ShinyCharm = false;
        }

        public Hunting(int Id = 0, int Generation = 6, TypeHunt Type = TypeHunt.Default, int Chain = 0, int DexLevel = 0, int Amount = 0, string Pokemon = "", double Odds = .00024, bool ShinyCharm = false)
        {
            this.Id = Id;
            this.Generation = Generation;
            this.Type = Type;
            this.Chain = Chain;
            this.DexLevel = DexLevel;
            this.Amount = Amount;
            this.Pokemon = Pokemon;
            this.Odds = Odds;
            this.ShinyCharm = ShinyCharm;
        }
    }
}
