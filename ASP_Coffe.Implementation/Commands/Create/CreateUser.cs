using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Application.Command;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Interfaces.Email;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Create
{
    public class CreateUser : ICreateUser
    {
        private readonly Coffee_Context _context;
        private readonly IEmail _sender;
        private readonly CreateUserValidator _validator;

        public CreateUser(Coffee_Context context, IEmail sender, CreateUserValidator validator)
        {
            _context = context;
            _sender = sender;
            _validator = validator;
        }

        public int id => 21;

        public string Name => "Creating new user.";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);//Continue i vraca json fajl sa errors greskama

            var role = _context.Roles.FirstOrDefault(x => x.Name == "User");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                RoleId = role.Id
            };
            
            _context.Users.Add(user);
            _context.SaveChanges();

            _sender.Send(new EmailSendDto
            {
                SentTo = user.Email,
                Subject = "Registration for Coffee Shop",
                Content = $"<h1>Hi {user.FirstName} {user.LastName}, your registration is successfull, we are glad that you trust us!</h1>"
            });

        }
    }
}
