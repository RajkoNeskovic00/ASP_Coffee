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
    public class GetBeans : IGetBeans
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;

        public GetBeans(Coffee_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int id => 1;

        public string Name => "Catching and showing coffees of specific bean type.";

        public PagedRerponse<BeanSearchDto> Execute(BeanSearch search)
        {
            var query = _context.Beans.Where(x => x.DeleteAt == null).Include(x => x.Coffees).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();

                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            var beans = query.Paged<BeanSearchDto, Bean>(search, _mapper);

            if (beans.Items.Count() == 0)
            {
                throw new EntityNotFound(typeof(Bean));
            }

            return beans;
        }
    }
}
