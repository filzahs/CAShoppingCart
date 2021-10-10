using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAShoppingCart.Models
{
    public class Product
    {
        public Product()
        {
            Id = new Guid();
            //order = new List<PurchaseRecord>();

        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; }

        public float Price { get; set; }

        [Required]
        [MaxLength(300)]
        public string Desc { get; set; }

        [Required]
        public string ImageFile { get; set; }

        public string Category { get; set; }

        // public virtual PurchaseRecord Orders {get; set;}
    }

    
}
