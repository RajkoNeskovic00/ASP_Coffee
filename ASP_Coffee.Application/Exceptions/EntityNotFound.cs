using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Exceptions
{
    public class EntityNotFound : Exception
    {
        public EntityNotFound(Type type)
            : base($"Entity: {type.Name} was not found.")
        {

        }
    }
}
