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
    public class CreateAmountValidator : AbstractValidator<AmountDto>
    {
        public CreateAmountValidator(Coffee_Context context)
        {
            RuleFor(x => x.AmountPack).NotEmpty().WithMessage("Pack amount is required.").DependentRules(() =>
            {
                RuleFor(x => x.AmountPack).Must(x => x >= 100).WithMessage("Pack amount must be higher or equal to 100.");
                RuleFor(x => x.AmountPack).Must(amount => !context.Amounts.Any(x => x.AmountPack == amount)).WithMessage("Pack amount already exists. Write new one!");
            });
        }
    }
}
