﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonShinyHuntingHelper.Data
{
    public interface IDataService
    {
        Task<IEnumerable<Hunting>> GetHuntHistory();
        Task<Hunting> GetHuntById(int Id);
        Task Hunt(Hunting hunt);
        Task Delete(Hunting hunt);
    }
}
