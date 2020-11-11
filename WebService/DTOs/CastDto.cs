using System.Collections.Generic;
using WebService.DataService.DTO;


namespace WebService.DTOs
{
    public class CastDto
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string CastId { get; set; }
        public string Category { get; set; }
        public string? Job { get; set; }
        public string? CharName { get; set; }
        //public virtual TitleDto Title { get; set; }
        //public virtual CastInfo CastInfo { get; set; }
    }
}
