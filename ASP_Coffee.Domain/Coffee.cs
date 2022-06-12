using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Domain
{
    public class Coffee : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int BeanId { get; set; }
        public int OriginId { get; set; }

        public virtual Origin Origin { get; set; }
        public virtual Bean Bean { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();

        public virtual ICollection<AmountCoffee> CoffeeAmounts { get; set; } = new HashSet<AmountCoffee>();
    }
}
