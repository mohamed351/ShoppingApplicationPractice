using ShoppingApplicationBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository.interfaces
{
    public interface ICategoryRepository:IRepository<Category,int>
    {
    }
}
