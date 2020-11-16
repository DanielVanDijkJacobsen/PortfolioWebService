namespace WebService.DataService.DMO
{
    public class NameRating
    {
        public string CastId { get; set; }
        public float Score { get; set; }
        public virtual CastInfo CastInfo { get; set; }
    }
}
