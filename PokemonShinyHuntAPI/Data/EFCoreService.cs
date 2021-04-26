using Microsoft.EntityFrameworkCore;
using PokemonShinyHunt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntAPI.Data
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

        public async Task<IEnumerable<Logs>> GetLogs()
        {
            return await applicationDBContext.Logging.ToListAsync();
        }

        public async Task AddLog(Logs log)
        {
            applicationDBContext.Logging.Add(log);
            await applicationDBContext.SaveChangesAsync();
        }

        public string ConvertHuntToString(Hunting hunt) 
        {
            string huntstring = $"Amount: {hunt.Amount} \n Chain: {hunt.Chain}\n DexLevel: {hunt.DexLevel} \n Pokemon: {hunt.Pokemon} \n DateStart:{hunt.Start} \n DateFinished:{hunt.Finish} \n HuntType:{hunt.Type}";
            return huntstring;
        }
    }
}
