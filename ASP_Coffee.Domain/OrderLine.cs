using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Domain
{
    public class OrderLine : Entity
    {
        public string NameCoffee { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public int AmountCoffeeId { get; set; }

        public virtual Order Order { get; set; }
        public virtual AmountCoffee AmountCoffee { get; set; }



    }
}
