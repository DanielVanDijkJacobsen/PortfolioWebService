using System.Collections.Generic;

namespace WebService.DataService.DMO
{
    public class TitleAlias
    {
        public string TitleId { get; set; }
        public virtual Titles Titles { get; set; }
        public int Ordering { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Attributes { get; set; }
        public bool IsOriginalTitle { get; set; }
        public virtual ICollection<TitleFormats> TitleFormat { get; set; }
    }
}
