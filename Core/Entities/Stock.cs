using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Stock
    {
        public int Id { get; set; }
 
        public int WholesalerId { get; set; }
        public Wholesaler wholesaler { get; set; }

        public int BeerId { get; set; }
        public Beer Beer { get; set; }

        public int QuantityStock { get; set; }
        public decimal PriceStock { get; set; }

    }
}
