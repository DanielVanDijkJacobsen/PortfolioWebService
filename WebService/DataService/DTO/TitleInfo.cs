namespace WebService.DataService.DTO
{
    public class TitleInfo
    {
        public virtual Titles Titles { get; set; }
        public string TitleId { get; set; }
        public string Awards { get; set; }
        public string? Plot { get; set; }
    }
}
