namespace WebService.DataService.DTO
{
    public class CastKnownFor
    {
        public string CastId { get; set; }
        public string KnownFor { get; set; }
        public virtual CastInfo CastInfo { get; set; }
    }
}
