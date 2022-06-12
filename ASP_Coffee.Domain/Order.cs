using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Domain
{
    public class Order : Entity
    {
        public string Address { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; } = new HashSet<OrderLine>();
    }
}
