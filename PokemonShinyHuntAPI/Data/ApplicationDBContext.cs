using Microsoft.EntityFrameworkCore;
using PokemonShinyHunt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Hunting> Hunting { get; set; }
        public DbSet<Logs> Logging { get; set; }
    }
}
