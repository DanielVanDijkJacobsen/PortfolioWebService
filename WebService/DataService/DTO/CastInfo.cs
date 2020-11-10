using System;
using System.Collections.Generic;

namespace WebService.DataService.DTO
{
    public class CastInfo
    {
        public string CastId { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        public virtual ICollection<Casts> Casts { get; set; }
        public virtual ICollection<CastProfession> CastProfession { get; set; }
        public virtual ICollection<CastKnownFor> CastKnownFor { get; set; }
    }
}
