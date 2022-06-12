using ASP_Coffee.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public string UseCaseName { get; set; }
    }
}
