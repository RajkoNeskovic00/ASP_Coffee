using ASP_Coffe.Implementation.Validators;
using ASP_Coffee.Application.Command;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Commands.Create
{
    public class CreateAmount : ICreateAmount
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;
        private readonly CreateAmountValidator _validator;

        public CreateAmount(Coffee_Context context, IMapper mapper, CreateAmountValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int id => 10;

        public string Name => "Creating new amount of package for coffees.";

        public void Execute(AmountDto request)
        {
            _validator.ValidateAndThrow(request);

            var amount = _mapper.Map<Amount>(request);
            _context.Amounts.Add(amount);
            _context.SaveChanges();
        }
    }
}
