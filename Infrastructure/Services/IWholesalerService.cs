using Core.Entities;

namespace Core.Services
{
    public interface IWholesalerService
    {
        void UpdateBeerStock(int wholesalerId, int beerId, int newQuantity);
        // QuoteResult RequestQuote(int wholesalerId, List<OrderItem> orderItems);
    }
}
