namespace WebService.DataService.DMO
{
    public class Casts
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string CastId { get; set; }
        public string Category { get; set; }
        public string? Job { get; set; }
        public string? CharName { get; set; }
        public virtual Titles Title { get; set; }
        public virtual CastInfo CastInfo { get; set; }
    }
}
