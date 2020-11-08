using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMDBDataService.Objects;

namespace WebService.DataTransferModels.Profiles
{
    public class TitleProfile : Profile
    {
        public TitleProfile()
        {
            CreateMap<Titles, TitleDto>();
            //CreateMap<TitleForCreationOrUpdateDto, Title>();
        }
    }
}
