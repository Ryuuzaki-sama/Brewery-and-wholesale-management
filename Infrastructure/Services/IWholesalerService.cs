using Core.Entities;

namespace Infrastructure.Services
{
    public interface IWholesalerService
    {
        // FR4
        Task<Sale> AddSaleBeerisStock(int wholesalerId, int beerId, int newQuantity);
        //FR5
        Task<Wholesaler> UpdateBeerStock(int wholesalerId, int beerId, int newQuantity);
        //FR6
        Task<Quote> RequestQuote(int wholesalerId, List<OrderItem> orderItems);
    }
}
