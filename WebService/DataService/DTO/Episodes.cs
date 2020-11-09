namespace WebService.DataService.DTO
{
    public class Episodes
    {
        public string EpisodeId { get; set; }
        public string SeriesId { get; set; }
        public int? SeasonNum { get; set; }
        public int? EpisodeNum { get; set; }
        public virtual Titles Episode { get; set; }
        public virtual Titles Series { get; set; }
    }
}
