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
    public class CreateBeanValidator : AbstractValidator<BeanDto>
    {
        public CreateBeanValidator(Coffee_Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Type of Bean name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !context.Beans.Any(x => x.Name == name)).WithMessage("Bean name already exists. Write new one!");
            });
        }
    }
}
