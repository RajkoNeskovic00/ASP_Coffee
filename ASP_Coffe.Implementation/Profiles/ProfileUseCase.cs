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
    public class ProfileUseCase : Profile
    {
        public ProfileUseCase()
        {
            CreateMap<UseCase, UseCaseLogDto>();
        }
    }
}
