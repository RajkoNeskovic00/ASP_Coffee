using ASP_Coffee.Application.DTO;
using ASP_Coffee.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_Coffe.Implementation.Profiles
{
    public class ProfileOrder : Profile
    {
        public ProfileOrder()
        {
            CreateMap<Order, OrderSearchDto>()
              .ForMember(x => x.OrderLineSearchDtos, y => y.MapFrom(o => o.OrderLines.Select(ol =>
              new OrderLineSearchDto
              {
                  CoffeeName = ol.NameCoffee,
                  Price = ol.Price,
                  Quantity = ol.Quantity

              })));
        }
    }
}
