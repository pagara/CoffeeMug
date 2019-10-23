using CoffeeMug.Data.Abstract;
using CoffeeMug.Data.Model;

namespace CoffeeMug.Data.Repositories
{
    public class ProductRepository : EntityBaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context) { }
        public bool IsProductAlreadyAdded(string name)
        {
            var isProductRegistered = this.Get(p => p.Name == name);
            return isProductRegistered == null;
        }
    }
}
