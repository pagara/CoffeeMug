using CoffeeMug.Data.Model;
using System;

namespace CoffeeMug.Data.Abstract
{
    public interface IProductRepository : IEntityBaseRepository<Product>
    {
        bool IsProductIdValid(Guid id);
    }
}
