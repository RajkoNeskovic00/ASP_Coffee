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
    public class GetOrigins : IGetOrigins
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;

        public GetOrigins(Coffee_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int id => 5;

        public string Name => "Catching and showing coffees origins.";

        public PagedRerponse<OriginsSearchDto> Execute(OriginSearch search)
        {
            var query = _context.Origins.Where(x => x.DeleteAt == null).Include(x => x.Coffees).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            var origins = query.Paged<OriginsSearchDto, Origin>(search, _mapper);

            if (origins.Items.Count() == 0)
            {
                throw new EntityNotFound(typeof(Origin));
            }

            return origins;
        }
    }
}
