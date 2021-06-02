using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DogWebApp.Dtos;
using DogWebApp.Models;

namespace DogWebApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dog, DogDto>().ReverseMap();
        }
    }
}
