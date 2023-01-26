using Core.Entities;
using Core.DTOs;

namespace Infrastructure.Services
{
    public interface IWholesalerService
    {
        Task<bool> AddSale(BeerDto beer, WholesalerDto wholesaler);
    Task<bool> UpdateStock(BeerDto beer, WholesalerDto wholesaler);
    Task<QuoteDto> RequestQuote(List<BeerDto> beers, WholesalerDto wholesaler, int quantity);
    }
}
