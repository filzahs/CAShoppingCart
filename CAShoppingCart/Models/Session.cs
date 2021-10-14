using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAShoppingCart.Models
{
    public class Session
    {
        public Session()
        {
            Id = new Guid();
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public Guid Id {get; set;}
        public virtual User User { get; set; } //when create a new session

        public long Timestamp { get; set; }
    }
}
