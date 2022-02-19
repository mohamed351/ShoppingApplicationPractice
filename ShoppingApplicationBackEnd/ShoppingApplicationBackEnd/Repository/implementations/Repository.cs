using ShoppingApplicationBackEnd.Models;
using ShoppingApplicationBackEnd.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository.implementations
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            this.context.Add(entity);
        }

        public void Delete(T entity)
        {
            this.context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            this.context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IEnumerable<T> GetAll()
        {
            return  this.context.Set<T>().ToList();
        }

        public T GetByID(TKey key)
        {
            return this.context.Set<T>().Find(key);
        }
    }
}
