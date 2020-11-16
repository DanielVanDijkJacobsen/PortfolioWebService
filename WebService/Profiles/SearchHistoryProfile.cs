using AutoMapper;
using WebService.DataService.DMO;
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
