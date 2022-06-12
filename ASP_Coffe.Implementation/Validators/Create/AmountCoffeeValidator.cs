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
    public class AmountCoffeeValidator : AbstractValidator<AmountCoffeeDto>
    {
        public AmountCoffeeValidator(Coffee_Context context)
        {
            RuleFor(x => x.AmountId).NotEmpty().WithMessage("You must pick the right amount for coffee.").DependentRules(() =>
            {
                RuleFor(x => x.AmountId).Must(amount => context.Amounts.Any(x => x.Id == amount)).WithMessage("You must choose amount that exists.");
            });
            RuleFor(x => x.Price).Must(price => price >= 100).WithMessage("Price must be greater or equal to 100");
        }
    }
}
