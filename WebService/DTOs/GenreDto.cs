using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.DTOs
{
    public class GenreDto
    {
        public int GenreId { get; set; }
        public string Genre { get; set; }
        //public virtual ICollection<TitleGenreDto> TitleGenres { get; set; }
    }
}
