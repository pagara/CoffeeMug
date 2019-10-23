using CoffeeMug.Data.Abstract;
using CoffeeMug.Data.Model;
using System;

namespace CoffeeMug.Data.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context) { }
        public bool IsProductIdValid(Guid id)
        {
            var IsIdValid = this.Get(p => p.Id == id);
            return IsIdValid == null;
        }
    }
}
