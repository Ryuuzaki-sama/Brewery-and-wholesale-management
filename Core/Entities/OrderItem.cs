namespace Core.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int BeerId { get; set; }
        public Beer BeerName { get; set; }
        public int WholesalerId { get; set; }
        public string WholesalerName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
