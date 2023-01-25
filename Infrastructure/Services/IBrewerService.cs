using Core.Entities;

namespace Infrastructure.Services
{
    public interface IBrewerService
    {
        IEnumerable<Beer> GetBeersByBrewery(int breweryId);
        void AddBeer(Beer beer);
        void DeleteBeer(int beerId);
    }
}
