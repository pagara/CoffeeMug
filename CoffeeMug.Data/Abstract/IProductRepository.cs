using CoffeeMug.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMug.Data.Abstract
{
    public interface IProductRepository : IEntityBaseRepository<Product>
    {
        bool IsProductAlreadyAdded(string name);
    }
}
