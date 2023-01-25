using Core.Entities;

namespace Infrastructure.Services
{
    public interface ISaleService
    {
        //FR4 : Add the sale of an existing beer to an existing wholesaler
        void AddSale(int wholesalerId, int beerId, int quantity);
    }
}
