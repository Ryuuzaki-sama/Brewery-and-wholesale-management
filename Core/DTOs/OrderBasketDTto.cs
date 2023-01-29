using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class OrderBasketDTto
    {
        [Required]
        public int Id { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }
}
}
