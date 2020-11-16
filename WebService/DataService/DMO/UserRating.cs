namespace WebService.DataService.DMO
{
    public class UserRating
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public float Score { get; set; }
        public virtual Users User { get; set; }
        public virtual Titles Title { get; set; }
    }
}
