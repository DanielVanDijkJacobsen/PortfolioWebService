using System.Collections.Generic;
using WebService.DataService.DMO;

namespace WebService.DTOs
{
    public class TitleDto
    {
        public string TitleId { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int? RuntimeMins { get; set; }
        public string Poster { get; set; }
        public string StartYear { get; set; }
        public string YearEnd { get; set; }
        public string Url { get; set; }
        public virtual TitleInfo TitleInfo { get; set; }
        public virtual ICollection<TitleAliasDto> TitleAlias { get; set; }
        public virtual ICollection<TitleGenreDto> TitleGenre { get; set; }
        public virtual ICollection<Casts> Casts { get; set; }
        public virtual ICollection<Episodes> Episodes { get; set; }
        public virtual ICollection<Episodes> Seasons { get; set; }
        public virtual ICollection<UserRating> UserRating { get; set; }
        public virtual ICollection<Bookmarks> Bookmarks { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
