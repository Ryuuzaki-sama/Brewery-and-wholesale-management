using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerDbContext _repo;

        public BeerRepository(BeerDbContext repo)
        {
            this._repo = repo;
        }

        public async Task<Beer> AddBeerWithBrewerIdAsync(Beer beer)
        {

            throw new NotImplementedException();
            
        }

        public async Task<Beer> DeleteBeerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Beer>> GetBeersBybrewerAsync(int BrewerId)
        {
            return await _repo.Beers.Where(x => x.Brewer.Id == BrewerId)
                .Include(x => x.Brewer)
                .ToListAsync();




        }

    }
}
