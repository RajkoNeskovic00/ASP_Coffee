using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Application.Command.Update;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Update
{
    public class UpdateOrigin : IUpdateOrigin
    {
        private readonly Coffee_Context _context;
        private readonly UpdateOriginValidator _validator;

        public UpdateOrigin(Coffee_Context context, UpdateOriginValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 7;

        public string Name => "Updating origin.";

        public void Execute(OriginDto request)
        {
            _validator.ValidateAndThrow(request);

            var origin = _context.Origins.Find(request.Id);

            if (origin == null)
            {
                throw new EntityNotFound(typeof(Origin));
            }

            origin.Name = request.Name;
            origin.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();

        }
    }
}
