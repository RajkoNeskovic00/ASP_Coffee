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
    public class OrderLineValidator : AbstractValidator<OrderLineDto>
    {
        public OrderLineValidator(Coffee_Context context)
        {
            RuleFor(x => x.CoffeeId).Must(coffee => context.Coffees.Any(x => x.Id == coffee)).WithMessage("Coffee You picked doesn't exist.");
            RuleFor(x => x.AmountId).Must(amount => context.Amounts.Any(x => x.Id == amount)).WithMessage("Pack amount You picked doesn't exist.");
            RuleFor(x => x.Quantity).Must(x => x > 0).WithMessage("Quantity must be higher than 0.");
        }
    }
}
