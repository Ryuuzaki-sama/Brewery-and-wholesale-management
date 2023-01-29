using Core.Entities;
using Core.DTOs;
using Brewery_and_wholesale_management.DTOs;

namespace Infrastructure.Services
{
    public interface IWholesalerService
    {
        Task<bool> AddSale(BeerDTO beer, WholesalerDto wholesaler);
        Task<bool> UpdateStock(BeerDTO beer, WholesalerDto wholesaler);
        Task<Quote> RequestQuote(List<BeerDTO> beers, WholesalerDto wholesaler, int quantity);
        Task GetBeersByWholesaler(int id);
    }
}
