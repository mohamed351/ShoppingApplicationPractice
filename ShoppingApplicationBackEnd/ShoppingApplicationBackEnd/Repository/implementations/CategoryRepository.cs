using ShoppingApplicationBackEnd.Models;
using ShoppingApplicationBackEnd.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository.implementations
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

    }
}
