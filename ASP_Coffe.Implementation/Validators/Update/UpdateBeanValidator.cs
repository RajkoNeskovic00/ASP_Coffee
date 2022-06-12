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
    public class UpdateBeanValidator : AbstractValidator<BeanDto>
    {
        public UpdateBeanValidator(Coffee_Context context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of the type of coffee bean is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((bean, name) => !context.Beans.Any(x => x.Name == name && x.Id != bean.Id)).WithMessage("Coffee bean with this name already exists.");
            });

        }
    }
}
