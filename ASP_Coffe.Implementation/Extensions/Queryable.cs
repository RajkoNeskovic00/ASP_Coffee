using ASP_Coffee.Application.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Extensions
{
    public static class Queryable
    {
        public static PagedRerponse<TDto> Paged<TDto, TEntity>(
          this IQueryable<TEntity> query, PagedSearch search, IMapper mapper)
          where TDto : class
        {
            var skipCount = search.PerPage * (search.Page - 1);

            var skipped = query.Skip(skipCount).Take(search.PerPage);

            var response = new PagedRerponse<TDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = mapper.Map<IEnumerable<TDto>>(skipped)
            };

            return response;
        }
    }
}
