using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Command
{
    public interface ICreateAmount : ICommand<AmountDto>
    {
    }
}
