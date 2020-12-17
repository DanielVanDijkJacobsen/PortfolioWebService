using System.Collections.Generic;

namespace WebService.DTOs
{
    public class CastInfoDto
    {
        public string CastId { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public virtual ICollection<CastDto> Casts { get; set; }
        public virtual ICollection<CastProfessionDto> CastProfession { get; set; }
        public virtual ICollection<CastKnownForDto> CastKnownFor { get; set; }
    }
}
