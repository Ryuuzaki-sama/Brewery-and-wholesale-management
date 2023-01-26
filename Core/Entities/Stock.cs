using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        [Required]
        public int WholesalerId { get; set; }
        [Required]
        public int BeerId { get; set; }

        [Required]
        public int QuantityStock { get; set; }
        [Required]
        public decimal PriceStock { get; set; }

    }
}
