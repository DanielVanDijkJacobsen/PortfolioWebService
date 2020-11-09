using System.Collections.Generic;


namespace WebService.DTOs
{
    public class CastDto
    {
        public string Id { get; set; }
        public string PrimaryName { get; set; }
        public List<string> CastTitlesIds;
    }
}
