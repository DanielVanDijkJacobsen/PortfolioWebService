namespace WebService.DataService.DTO
{
    public class SpecialRoles
    {
        public int UserId { get; set; }
        public string RoleType { get; set; }
        public virtual Users User { get; set; }
    }
}
