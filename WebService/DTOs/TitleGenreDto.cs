using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DTOs
{
    public class TitleGenreDto
    {
        public string TitleId { get; set; }
        //public virtual TitleDto Title { get; set; }
        public int GenreId { get; set; }
        public virtual GenreDto Genre { get; set; }
    }
}
