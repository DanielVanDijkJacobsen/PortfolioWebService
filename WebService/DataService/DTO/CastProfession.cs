namespace WebService.DataService.DTO
{
    public class CastProfession
    {
        public string CastId { get; set; }
        public string Profession { get; set; }
        public virtual CastInfo CastInfo { get; set; }
    }
}
