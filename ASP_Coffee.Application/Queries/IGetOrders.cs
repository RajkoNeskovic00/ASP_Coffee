using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Interfaces;
using ASP_Coffee.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Queries
{
    public interface IGetOrders : IQuery<OrderSearch, PagedRerponse<OrderSearchDto>>
    {
    }
}
