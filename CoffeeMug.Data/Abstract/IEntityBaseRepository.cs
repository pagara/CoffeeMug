using CoffeeMug.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CoffeeMug.Data.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}
