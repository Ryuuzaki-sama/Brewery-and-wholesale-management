using Core.Entities;

namespace Brewery_and_wholesale_management.Core.Interfaces
{
    public interface IWholesolerRepository
    {
        Task<Wholesaler> AddBeerWithBrewerIdAsync(Wholesaler wholesaler);
        Task<Beer> DeleteBeerAsync(int id);
    }
}
