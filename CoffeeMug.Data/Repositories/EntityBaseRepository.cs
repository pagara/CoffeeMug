using CoffeeMug.Data.Abstract;
using CoffeeMug.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoffeeMug.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private ProductContext _context;

        public EntityBaseRepository(ProductContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> entity = _context.Set<T>();
            return entity.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public void Update(T entity)
        {
            EntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
}
