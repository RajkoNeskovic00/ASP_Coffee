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
    public class UpdateBean : IUpadateBean
    {
        private readonly Coffee_Context _context;
        private readonly UpdateBeanValidator _validator;

        public UpdateBean(Coffee_Context context, UpdateBeanValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 3;

        public string Name => "Updating type of coffee bean.";

        public void Execute(BeanDto request)
        {
            _validator.ValidateAndThrow(request);

            var bean = _context.Beans.Find(request.Id);

            if (bean == null)
            {
                throw new EntityNotFound(typeof(Bean));
            }

            bean.Name = request.Name;
            bean.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
