#nullable enable
using System.Collections.Generic;

namespace WebService.DataService.DMO
{
    public class Titles
    {

        public string TitleId { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int? RunetimeMins { get; set; }
        public string? Poster { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public virtual TitleInfo TitleInfo { get; set;}
        public virtual ICollection<TitleAlias> TitleAlias { get; set;}
        public virtual ICollection<TitleGenres> TitleGenre { get; set; }
        public virtual ICollection<Casts> Casts { get; set; }
        public virtual ICollection<Episodes> Episodes { get; set; }
        public virtual ICollection<Episodes> Seasons { get; set; }
        public virtual ICollection<UserRating> UserRating { get; set; }
        public virtual ICollection<Bookmarks> Bookmarks { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
