using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Wholesaler : BaseEntity
    {
        public string Name { get; set; }
        public List<Stock>? Stocks { get; set; }
        public List<Sale>? Sales { get; set; }

        public int BeerId { get; set; }

        public List<Beer> Beers { get; set; }


    }
}
