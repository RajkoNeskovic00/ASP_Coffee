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
    public class CreateBean : ICreateBean
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;
        private readonly CreateBeanValidator _validator;

        public CreateBean(Coffee_Context context, IMapper mapper, CreateBeanValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int id => 2;

        public string Name => "Creating new type of coffee bean.";

        public void Execute(BeanDto request)
        {
            _validator.ValidateAndThrow(request);
            var bean = _mapper.Map<Bean>(request);
            _context.Beans.Add(bean);
            _context.SaveChanges();
        }
    }
}
