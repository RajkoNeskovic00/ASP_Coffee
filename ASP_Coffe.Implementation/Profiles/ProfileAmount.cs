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
    public class ProfileAmount : Profile
    {
       public ProfileAmount()
       {
            CreateMap<Amount, AmountSearchDto>()
                .ForMember(x => x.Coffees, y => y.MapFrom(coffee => coffee.AmountCoffees.Select(c =>
                           new CoffeeSearchDto
                           {
                               Id = c.Coffee.Id,
                               Name = c.Coffee.Name,
                               Description = c.Coffee.Description                      
                           }
                     )));
            CreateMap<AmountDto, Amount>();
       }
    }
}
