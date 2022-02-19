using ShoppingApplicationBackEnd.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository
{
   public interface IUnitOfWork
    {
       public  IAuthRepository AuthRepository { get; }
        public ICategoryRepository CategoryRepository { get; }


        public int Complate();
        


    }
}
