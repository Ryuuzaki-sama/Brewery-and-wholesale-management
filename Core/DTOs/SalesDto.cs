using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class SalesDto
    {
        public int Id { get; set; }
        public string Wholesaler { get; set; }
        public string Beer { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be atleast 1")]
        public int QuantitySale { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal PriceSale { get; set; }
    }
}
