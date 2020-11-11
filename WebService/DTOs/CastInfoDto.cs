using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DTOs
{
    public class CastInfoDto
    {
        public string CastId { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        //public virtual ICollection<Casts> Casts { get; set; }
        public virtual ICollection<CastProfessionDto> CastProfession { get; set; }
        public virtual ICollection<CastKnownForDto> CastKnownFor { get; set; }
    }
}
