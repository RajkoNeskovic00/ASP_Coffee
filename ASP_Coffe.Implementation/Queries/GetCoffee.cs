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
    public class GetCoffee : IGetCoffee
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;

        public GetCoffee(Coffee_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int id => 13;

        public string Name => "Catching and showing coffees.";

        public PagedRerponse<CoffeeSearchDto> Execute(CoffeeSearch search)
        {
            var query = _context.Coffees.Include(x => x.CoffeeAmounts)
                                        .ThenInclude(x => x.Amount)
                                        .Where(x => x.DeleteAt == null).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            var coffees = query.Paged<CoffeeSearchDto, Coffee>(search, _mapper);

            if (coffees.Items.Count() == 0)
            {
                throw new EntityNotFound(typeof(Coffee));
            }

            return coffees;


        }
    }
}
