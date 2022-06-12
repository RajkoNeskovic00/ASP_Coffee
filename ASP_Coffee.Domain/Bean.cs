using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Domain
{
    public class Bean : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Coffee> Coffees { get; set; } = new HashSet<Coffee>();
    }
}
