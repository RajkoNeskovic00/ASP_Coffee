
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
    public class ProfileBean : Profile
    {
        public ProfileBean()
        {
            CreateMap<Bean, BeanSearchDto>()
               .ForMember(x => x.Coffees, y => y.MapFrom(coffee => coffee.Coffees.Select(c =>
               new CoffeeSearchDto
               {
                   Id = c.Id,
                   Name = c.Name,
                   Description = c.Description
               })));

            CreateMap<BeanDto, Bean>();
        }
    }
}
