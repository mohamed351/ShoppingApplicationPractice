using ShoppingApplicationBackEnd.Models;
using ShoppingApplicationBackEnd.Repository.implementations;
using ShoppingApplicationBackEnd.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            AuthRepository = new AuthRepository(context);
            CategoryRepository = new CategoryRepository(context);
            this.context = context;
        }
        public IAuthRepository AuthRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public int Complate()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
