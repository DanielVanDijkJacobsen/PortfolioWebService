namespace WebService.DataService.DMO
{
    public class TitleFormats
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public virtual TitleAlias TitleAlias { get; set; }
        public int FormatId { get; set; }
        public virtual Formats Format { get; set; }
    }
}
