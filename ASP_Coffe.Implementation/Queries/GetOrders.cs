using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP_Coffe.Implementation.Extensions;
using ASP_Coffee.Application.DTO;
using ASP_Coffee.Application.Exceptions;
using ASP_Coffee.Application.Interfaces;
using ASP_Coffee.Application.Queries;
using ASP_Coffee.Application.Searches;
using ASP_Coffee.DataAccess;
using ASP_Coffee.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASP_Coffe.Implementation.Queries
{
    public class GetOrders : IGetOrders
    {
        private readonly Coffee_Context _context;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;

        public GetOrders(Coffee_Context context, IMapper mapper, IApplicationActor actor)
        {
            _context = context;
            _mapper = mapper;
            _actor = actor;
        }

        public int id => 18;

        public string Name => "Catching and showing coffees of specific package amount.";

        public PagedRerponse<OrderSearchDto> Execute(OrderSearch search)
        {
            var query = _context.Orders.Include(x => x.OrderLines).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();
                query = query.Where(x => x.OrderLines.Any(o => o.NameCoffee.Contains(search.Name)));
            }

            //var user = _context.Users.Find(_actor.Id);

            //if(user.RoleId == 2)
            //{
            //query = query.Where(x => x.UserId == user.Id);
            //}

            var orders = query.Paged<OrderSearchDto, Order>(search, _mapper);

            if (orders.Items.Count() == 0)
            {
                throw new EntityNotFound(typeof(Order));
            }

            return orders;
        }
    }
}
