using ASP_Coffee.Application.DTO;
using ASP_Coffee.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Validators
{
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        public CreateOrderValidator(Coffee_Context context)
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required before ordering our coffee. ");

            RuleFor(x => x.OrderLines).NotEmpty().WithMessage("You must acquire coffees to Your order cart.").DependentRules(() =>
            {
                RuleFor(x => x.OrderLines).Must(orderLines =>
                    orderLines.Select(o => o.CoffeeId + o.AmountId).Distinct().Count() == orderLines.Count()
                ).WithMessage("You duplicated order lines!").DependentRules(() =>
                {
                    RuleForEach(x => x.OrderLines).SetValidator(new OrderLineValidator(context));
                });
            });
        }
    }
}
