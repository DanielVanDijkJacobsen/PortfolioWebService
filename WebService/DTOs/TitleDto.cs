using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBDataService.Objects;

namespace WebService.DTOs
{
    public class TitleDto
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int? RuntimeMins { get; set; }
        public string Poster { get; set; }
        public string StartYear { get; set; }
        public string YearEnd { get; set; }

        public virtual ICollection<TitleInfo> TitleInfo { get; set; }
        public virtual ICollection<TitleAlias> TitleAlias { get; set; }
        public virtual ICollection<TitleGenres> TitleGenre { get; set; }

        public virtual ICollection<Casts> Casts { get; set; }

        public virtual ICollection<Episodes> Episodes { get; set; }

        public virtual ICollection<Episodes> Seasons { get; set; }

        public virtual ICollection<UserRating> UserRating { get; set; }
        public virtual ICollection<Bookmarks> Bookmarks { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
