using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }


        public byte[] PasswordHash { get; set; }


        public byte[] PasswordSalt { get; set; }


        public bool IsActive { get; set; }

        public string RoleName { get; set; }


        public string Email { get; set; }


        public string Phone { get; set; }
    }
}
