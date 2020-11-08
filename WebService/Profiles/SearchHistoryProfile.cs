using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMDBDataService.Objects;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class SearchHistoryProfile : Profile
    {
        public SearchHistoryProfile()
        {
            CreateMap<SearchHistory, SearchHistoryDto>();
        }
    }
}
