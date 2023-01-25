using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Beer : BaseEntity
    {
        public string Name { get; set; }
        [Required]
        public double Alcohol_content { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int BrewerId { get; set; }
        public Brewer? Brewer { get; set; }
        
    }
}
