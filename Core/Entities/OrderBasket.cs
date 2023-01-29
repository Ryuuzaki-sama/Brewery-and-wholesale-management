using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class OrderBasket
    {
        public OrderBasket()
        {
        }

        public OrderBasket(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public List<OrderItem> Order { get; set; } = new List<OrderItem>();
    }
}
