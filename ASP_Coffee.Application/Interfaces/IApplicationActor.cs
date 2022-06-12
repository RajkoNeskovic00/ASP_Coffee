using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Interfaces
{
    public interface IApplicationActor
    {
        public int Id{get;}
        public string Email { get; }
        public IEnumerable<int> AllowedUseCases { get; }
    }
}
