using System.Collections.Generic;

namespace WebService.DataService.DMO
{
    public class Formats
    {
        public int FormatId { get; set; }
        public string Format { get; set; }
        public virtual ICollection<TitleFormats> TitleFormats { get; set; }
    }
}
