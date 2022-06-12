using ASP_Coffe.Implementation.Extensions;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.Application.Queries;
using ASP_Coffee.Application.Searches;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Queries
{
    public class GetUseCaseLogs : IGetUseCaseLogs
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;

        public GetUseCaseLogs(Coffee_Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int id => 20;

        public string Name => "Fetching and showing use case logs.";

        public PagedRerponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCases.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName) && !string.IsNullOrWhiteSpace(search.UseCaseName))
            {

                search.UseCaseName = search.UseCaseName.ToLower();

                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName));
            }

            var useCaseLogs = query.Paged<UseCaseLogDto, UseCase>(search, _mapper);

            if (useCaseLogs.Items.Count() == 0)
            {
                throw new EntityNotFound(typeof(UseCase));
            }

            return useCaseLogs;
        }
    }
}
