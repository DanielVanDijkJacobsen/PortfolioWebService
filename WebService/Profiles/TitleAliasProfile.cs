using AutoMapper;
using WebService.DataService.DMO;
using WebService.DTOs;

namespace WebService.Profiles
{
    public class TitleAliasProfile : Profile
    {
        public TitleAliasProfile()
        {
            CreateMap<TitleAlias, TitleAliasDto>();
        }
    }
}
