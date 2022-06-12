using ASP_Coffee.Application.Interfaces;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly Coffee_Context _context;

        public DatabaseUseCaseLogger(Coffee_Context conext)
        {
            _context = conext;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            _context.UseCases.Add(new UseCase
            {
                UserId = actor.Id,
                UseCaseName = useCase.Name,
                Email = actor.Email,
                UseCaseDate = DateTime.UtcNow,
                Data = JsonConvert.SerializeObject(data)
            });

            _context.SaveChanges();
        }
    }
}
