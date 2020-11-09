namespace WebService.DataService.DTO
{
    public class TitleGenres
    {
        public string TitleId { get; set; }
        public virtual Titles Title { get; set; }
        public int GenreId { get; set; }
        public virtual Genres Genre { get; set; }
    }
}
