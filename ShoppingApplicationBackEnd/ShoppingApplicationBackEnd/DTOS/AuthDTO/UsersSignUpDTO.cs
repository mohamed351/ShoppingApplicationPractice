using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.DTOS
{
    public class UsersSignUpDTO
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]

        public string Email { get; set; }
    }
}
