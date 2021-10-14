using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAShoppingCart.Models
{
    public class User
    {
        public User()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
