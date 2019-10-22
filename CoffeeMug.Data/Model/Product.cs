using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMug.Data.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
