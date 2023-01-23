namespace Core.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

    }
}
