using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Application.Command.Update;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Update
{
    public class UpdateCoffee : IUpdateCoffee
    {
        private readonly Coffee_Context _context;
        private readonly UpdateCoffeeValidator _validator;

        public UpdateCoffee(Coffee_Context context, UpdateCoffeeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 15;

        public string Name => "Updating coffee.";

        public void Execute(CoffeeDto request)
        {
            _validator.ValidateAndThrow(request);

            var coffee = _context.Coffees.Find(request.Id);

            if (coffee == null)
            {
                throw new EntityNotFound(typeof(Coffee));
            }

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);
            var newImage = guid + extension;

            coffee.Name = request.Name;
            coffee.Description = request.Description;
            coffee.ImagePath = newImage;
            coffee.BeanId = request.BeanId;
            coffee.OriginId = request.OriginId;
            coffee.CoffeeAmounts = request.CoffeeAmounts.Select(x =>
            {
                return new AmountCoffee
                {
                    AmountId = x.AmountId,
                    Price = x.Price
                };
            }).ToList();

            coffee.ModifiedAt = DateTime.UtcNow;
            _context.SaveChanges();

        }
    }
}
