using ASP_Coffee.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffee.Application.Exceptions
{
    public class UnauthorizedUseCase : Exception
    {
        public UnauthorizedUseCase(IUseCase useCase, IApplicationActor actor)
           : base($"Actor with an email:{actor.Email}, with an id - '{actor.Id}', tried to execute: {useCase.Name}.")
        {

        }
    }
}
