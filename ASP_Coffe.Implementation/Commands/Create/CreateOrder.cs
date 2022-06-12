using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Application.Command;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.Application.Interfaces;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Create
{
    public class CreateOrder : ICreateOrder
    {
        private readonly Coffee_Context _context;
        private readonly CreateOrderValidator _validator;
        private readonly IApplicationActor _actor;

        public CreateOrder(Coffee_Context context, CreateOrderValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int id => 17;

        public string Name => "Creating coffee order.";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order
            {
                Address = request.Address,
                DateOfOrder = DateTime.UtcNow,
                UserId = _actor.Id,
                OrderLines = request.OrderLines.Select(x =>
                {
                    var coffee = _context.Coffees.Find(x.CoffeeId);

                    if (coffee == null)
                    {
                        throw new EntityNotFound(typeof(Coffee));
                    }

                    var coffeeAmount = _context.AmountCoffees.Where(c => c.CoffeeId == x.CoffeeId).Where(c => c.AmountId == x.AmountId).First();

                    if (coffeeAmount == null)
                    {
                        throw new EntityNotFound(typeof(Coffee));
                    }

                    return new OrderLine
                    {
                        NameCoffee = coffee.Name,
                        Quantity = x.Quantity,
                        AmountCoffeeId = coffeeAmount.Id,
                        Price = coffeeAmount.Price
                    };
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
