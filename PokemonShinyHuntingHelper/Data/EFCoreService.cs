using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntingHelper.Data
{
    public class EFCoreService : IDataService
    {
        private readonly ApplicationDBContext applicationDBContext;
        
        public EFCoreService(ApplicationDBContext applicationDBContext)
        {
           this.applicationDBContext = applicationDBContext ?? throw new ArgumentNullException(nameof(applicationDBContext));

        }

        public async Task<IEnumerable<Hunting>> GetHuntHistory()
        {
            return await applicationDBContext.Hunting.ToListAsync();
        }



        public async Task<Hunting> GetHuntById(int Id)
        {
            return await applicationDBContext.Hunting.Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task Hunt(Hunting hunt)
        {
            applicationDBContext.Hunting.Add(hunt);
            await applicationDBContext.SaveChangesAsync();
        }

        public async Task Delete(Hunting hunt) 
        {
            applicationDBContext.Hunting.Remove(hunt);
            await applicationDBContext.SaveChangesAsync();
        }
    }
}
