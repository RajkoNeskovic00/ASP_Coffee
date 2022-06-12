using ASP_Coffee.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Searches
{
    public class OrderSearch :PagedSearch
    {
        public string Name { get; set; }
    }
}
