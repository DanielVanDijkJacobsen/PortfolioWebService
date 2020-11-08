using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLibrary;

namespace WebService.DataTransferModels.Profiles
{
    public class CastProfile : Profile
    {
        public CastProfile()
        {
            CreateMap<Cast, CastDto>();
        }
    }
}
