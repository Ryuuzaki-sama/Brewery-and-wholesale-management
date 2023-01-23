using Core.Entities;

namespace Core.Services
{
    public interface ISaleService
    {
        void AddSale(int wholesalerId, int beerId, int quantity);
    }
}
