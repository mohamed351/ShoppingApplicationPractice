using Microsoft.EntityFrameworkCore;
using ShoppingApplicationBackEnd.Models;
using ShoppingApplicationBackEnd.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Repository.implementations
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext context;

        public AuthRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var currentUser = await context.Users.FirstOrDefaultAsync(a => a.UserName == username);
            if(currentUser == null)
            {
                return null;
            }

           var isCorrectPassword  = await VerifyPasswordHashing(password, currentUser.PasswordHash, currentUser.PasswordSalt);
            if (isCorrectPassword)
            {
                return currentUser;
            }
            
            return null;
        }

        public async Task<User> SignUp(User user, string password)
        {

            byte[] passwordHash = null;
            byte[] passwrodSalut = null;
            PasswordHashing(password, ref passwordHash,ref passwrodSalut);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwrodSalut;
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
            

        }

        private async Task<bool> VerifyPasswordHashing(string password, byte[] passwordHashed, byte[] passwordSalt)
        {
            using (var hasing = new HMACSHA512(passwordSalt))
            {

                var newPasswordHashing = hasing.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < newPasswordHashing.Length; i++)
                {
                    if (newPasswordHashing[i] != passwordHashed[i]) return false;
                }
            }
            return await Task.FromResult(true);

        }
        private void PasswordHashing(string passsword, ref byte[] passwordHashing, ref byte[] passwordSalting)
        {
            using (var hasing = new HMACSHA512())
            {

                passwordHashing = hasing.ComputeHash(Encoding.UTF8.GetBytes(passsword));
                passwordSalting = hasing.Key;
            }
        }
    }
}
