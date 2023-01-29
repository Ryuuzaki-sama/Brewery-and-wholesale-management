namespace Brewery_and_wholesale_management.DTOs
{
    public class BeerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public double Alcohol_content { get; set; }
        public string BrewerName { get; set; }

        public int WholesalerId { get; set; }

    }
}
