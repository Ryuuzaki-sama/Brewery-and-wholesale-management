

namespace Core.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public int BeerId { get; set; }
        public int QuantitySale { get; set; }
        public decimal PriceSale { get; set; }


    }
}
