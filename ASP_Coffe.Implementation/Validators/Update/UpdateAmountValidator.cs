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
    public class UpdateAmountValidator : AbstractValidator<AmountDto>
    {
        public UpdateAmountValidator(Coffee_Context context)
        {
            RuleFor(x => x.AmountPack).NotEmpty().WithMessage("Pack amount is required.").DependentRules(() =>
            {
                RuleFor(x => x.AmountPack).Must(x => x >= 100).WithMessage("Pack amount must be higher or equal to 100.");
                RuleFor(x => x.AmountPack).Must((amount, packAmount) => !context.Amounts.Any(x => x.AmountPack == packAmount && x.Id != amount.Id)).WithMessage("This pack amount already exists.");
            });
        }
    }
}
