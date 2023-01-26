using Core.Entities;

namespace Brewery_and_wholesale_management.Core.Interfaces
{
    public interface IWholesolerRepository
    {
        Task<bool> AddSale(BeerDto beer, WholesalerDto wholesaler);
        Task<Beer> DeleteBeerAsync(int id);
    }
}
