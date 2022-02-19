using ShoppingApplicationBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository.interfaces
{
    public interface IAuthRepository
    {

        Task<User> SignUp(User user, string password);

       Task<User> Login(string username, string password);

    }
}
