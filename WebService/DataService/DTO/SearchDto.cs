using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DTOs;

namespace WebService.DataService.DTO
{
    public class SearchDto
    {
        public IEnumerable<TitleDto> Titles { get; set; }
        public IEnumerable<CastInfoDto> Casts { get; set; }
    }
}
