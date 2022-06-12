using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Application.Command;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Create
{
    public class CreateCoffee : ICreateCoffee
    {
        private readonly Coffee_Context _context;
        private readonly CreateCoffeeValidator _validator;

        public CreateCoffee(Coffee_Context context, CreateCoffeeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 14;

        public string Name => "Creating new coffee.";

        public void Execute(CoffeeDto request)
        {
            _validator.ValidateAndThrow(request);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);
            var newImageName = guid + extension;

            var coffee = new Coffee
            {
                Name = request.Name,
                Description = request.Description,
                ImagePath = newImageName,
                OriginId = request.OriginId,
                BeanId = request.BeanId,
                CoffeeAmounts = request.CoffeeAmounts.Select(x =>
                {
                    return new AmountCoffee
                    {
                        AmountId = x.AmountId,
                        Price = x.Price
                    };
                }).ToList()
            };

            _context.Coffees.Add(coffee);
            _context.SaveChanges();
        }
    }
}
