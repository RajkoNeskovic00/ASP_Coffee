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
    public class CreateOrigin : ICreateOrigin
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;
        private readonly CreateOriginValidator _validator;

        public CreateOrigin(Coffee_Context context, IMapper mapper, CreateOriginValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int id => 6;

        public string Name => "Creating new coffee origin.";

        public void Execute(OriginDto request)
        {
            _validator.ValidateAndThrow(request);
            var origin = _mapper.Map<Origin>(request);
            _context.Origins.Add(origin);
            _context.SaveChanges();
        }
    }
}
