using System.Collections.Generic;
using WebService.DTOs;

namespace WebService.DataService.DMO
{
    public class SearchDto
    {
        public IEnumerable<TitleDto> Titles { get; set; }
        public IEnumerable<CastInfoDto> Casts { get; set; }
    }
}
