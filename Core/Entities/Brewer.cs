using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Brewer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Beer>? Beers { get; set; }
    }
}