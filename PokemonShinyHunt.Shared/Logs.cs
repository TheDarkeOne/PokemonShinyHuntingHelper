using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonShinyHunt.Shared
{
    public class Logs
    {
        public int Id { get; set; }
        public DateTime LogDate { get; set; }
        public string LogMessage { get; set; }
        public bool IsErrorLog { get; set; }
        public bool IsActivityLog { get; set; }
    }
}
