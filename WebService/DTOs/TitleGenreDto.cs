
namespace WebService.DTOs
{
    public class TitleGenreDto
    {
        public string TitleId { get; set; }
        public int GenreId { get; set; }
        public virtual GenreDto Genre { get; set; }
    }
}
