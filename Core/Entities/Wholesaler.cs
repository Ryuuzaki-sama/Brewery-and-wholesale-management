using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Wholesaler : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Stock>? Stock { get; set; }
        public ICollection<Sale>? Sales { get; set; }

        public int BeerId { get; set; }

        public List<Beer> Beers { get; set; }


    }
}
