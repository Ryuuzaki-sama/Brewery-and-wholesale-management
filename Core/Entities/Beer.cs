using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public double Alcohol_content { get; set; }
        public decimal Price { get; set; }

        [Required]
        public int BrewerId { get; set; }
        public Brewer? Brewer { get; set; }
        
    }
}
