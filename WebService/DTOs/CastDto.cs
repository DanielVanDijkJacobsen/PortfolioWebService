using System.Collections.Generic;


namespace WebService.DTOs
{
    public class CastDto
    {
        public string TitleId { get; set; } //Why is the TitleId here?
        public int Ordering { get; set; }
        public string CastId { get; set; }
        public string Category { get; set; }
        public string? Job { get; set; }
        public string? CharName { get; set; }
        public string Url { get; set; }

        public Dictionary<string, string> TitleIdUrlDictionary; //Needs support somehow.
        //public virtual TitleDto Title { get; set; }
        //public virtual CastInfo CastInfo { get; set; }
    }
}
