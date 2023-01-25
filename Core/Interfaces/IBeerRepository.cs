using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBeerRepository
    {
        Task<IReadOnlyList<Beer>> GetBeersBybrewerAsync(int BrewerId);
        Task<Beer> AddBeerWithBrewerIdAsync(Beer beer);
        Task<Beer> DeleteBeerAsync(int id);
    }
}
