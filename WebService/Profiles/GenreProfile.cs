using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebService.DataService.DTO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genres, GenreDto>();
        }
    }
}
