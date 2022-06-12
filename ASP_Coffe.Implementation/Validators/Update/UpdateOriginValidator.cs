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
    public class UpdateOriginValidator : AbstractValidator<OriginDto>
    {
        public UpdateOriginValidator(Coffee_Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of the origin is required.").DependentRules(() =>
            {
                //RuleFor(x => x.Name).MinimumLength(4).MaximumLength(15).Matches("^[A-Z][a-z]").WithMessage("The format of origin name isn't correct.");
                RuleFor(x => x.Name).Must((origin, name) => !context.Origins.Any(x => x.Name == name && x.Id != origin.Id)).WithMessage("Origin with this name already exists.");
            });
        }
    }
}
