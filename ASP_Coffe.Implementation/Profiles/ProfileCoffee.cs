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
    public class ProfileCoffee : Profile
    {
        public ProfileCoffee()
        {
            CreateMap<Coffee, CoffeeSearchDto>()
                
                .ForMember(x => x.Amounts,      
                           y => y.MapFrom(coffee =>
                           coffee.CoffeeAmounts
                .Select(c =>
                new AmountCoffeePriceDto
                {
                    Id = c.Id,
                    PackAmount = c.Amount.AmountPack,
                    Price = c.Price
                   
                })));
           
        }
        
    }
}
