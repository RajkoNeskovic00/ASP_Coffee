using ASP_Coffe.Implementation.Extensions;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.Application.Queries;
using ASP_Coffee.Application.Searches;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Queries
{
    public  class GetAmounts : IGetAmounts
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;

        public GetAmounts(Coffee_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int id => 9;

        public string Name => "Catching and showing coffees of specific package amount.";

        public PagedRerponse<AmountSearchDto> Execute(AmountSearch search)
        {
            var query = _context.Amounts.Where(x => x.DeleteAt == null).Include(x => x.AmountCoffees).ThenInclude(x => x.Coffee).AsQueryable();

            if (search.MinAmount.HasValue)
            {
                query = query.Where(x => x.AmountPack >= search.MinAmount);
            }

            if (search.MaxAmount.HasValue)
            {
                query = query.Where(x => x.AmountPack <= search.MinAmount);
            }

            var amounts = query.Paged<AmountSearchDto, Amount>(search, _mapper);

            if (amounts.Items.Count() == 0)
            {
                throw new EntityNotFound(typeof(Amount));
            }

            return amounts;
        }
    }
}
