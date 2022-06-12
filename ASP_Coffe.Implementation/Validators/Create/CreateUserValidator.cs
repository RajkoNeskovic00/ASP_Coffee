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
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(Coffee_Context context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Your first name is required.").DependentRules(() =>
            {
                RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(20).Matches(@"^[A-Z][a-z]{2,}(\s[A-Za-z]{2,})*").WithMessage("The format of first name isn't correct.");
            });

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Your last name is required.").DependentRules(() =>
            {
                RuleFor(x => x.LastName).MinimumLength(5).MaximumLength(20).Matches(@"^[A-Z][a-z]{2,}(\s[A-Za-z]{2,})*").WithMessage("The format of last name isn't correct.");
            });

            RuleFor(x => x.Email).NotEmpty().WithMessage("Your email is required.").EmailAddress().WithMessage("Email is not in the correct format.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Email).Must(email => !context.Users.Any(x => x.Email == email)).WithMessage("User email already exists. Write new email!");
                });

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.").DependentRules(() =>
            {
                //RuleFor(x => x.Password).Must(pass => !context.Users.Any(x => x.Password == pass)).WithMessage("Password already exits. Write new password!");
                RuleFor(x => x.Password).MinimumLength(6).Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
                                                         .WithMessage("The password must contain a minimum of 8 characters, one uppercase, one lowercase letter, number and special character.");
            });

            RuleFor(x => x.RoleId).Must(id => context.Roles.Any(x => x.Id == id)).WithMessage("Choosen role doesn't exist.");
        }
    }
}
