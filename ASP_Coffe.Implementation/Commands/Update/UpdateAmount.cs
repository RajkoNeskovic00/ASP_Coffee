using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Application.Command.Update;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Update
{
    public class UpdateAmount : IUpdateAmount
    {
        private readonly Coffee_Context _context;
        private readonly UpdateAmountValidator _validator;

        public UpdateAmount(Coffee_Context context, UpdateAmountValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int id => 11;

        public string Name => "Updating pack amount.";

        public void Execute(AmountDto request)
        {
            _validator.ValidateAndThrow(request);

            var amount = _context.Amounts.Find(request.Id);

            if (amount == null)
            {
                throw new EntityNotFound(typeof(Amount));
            }

            amount.AmountPack = request.AmountPack;
            amount.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
