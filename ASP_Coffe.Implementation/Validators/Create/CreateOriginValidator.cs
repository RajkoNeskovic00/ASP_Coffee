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
    public class CreateOriginValidator : AbstractValidator<OriginDto>
    {
        public CreateOriginValidator(Coffee_Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Coffee origin name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !context.Origins.Any(x => x.Name == name)).WithMessage("Coffee origin name already exists. Write new one!");
            });
        }
    }
}
