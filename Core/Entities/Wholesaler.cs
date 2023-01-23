using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Wholesaler
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Stock> Stock { get; set; }
        public ICollection<Sale> Sales { get; set; }


    }
}
