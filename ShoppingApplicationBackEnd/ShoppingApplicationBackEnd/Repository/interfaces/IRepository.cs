using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository.interfaces
{
   public interface IRepository<T ,TKey> where T:class
    {

        IEnumerable<T> GetAll();

        T GetByID(TKey key);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

    }
}
