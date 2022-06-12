using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Domain
{
    public  class Amount : Entity
    {
        public int AmountPack { get; set; }
        public virtual ICollection<AmountCoffee> AmountCoffees { get; set; } = new HashSet<AmountCoffee>();
    }
}
