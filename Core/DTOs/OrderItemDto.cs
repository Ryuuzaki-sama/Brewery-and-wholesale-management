﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string BeerName { get; set; }
        public string WholesalerName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
}
