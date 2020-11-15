using System.ComponentModel.DataAnnotations.Schema;
using WebService.DataService.CustomTypes;

namespace WebService.DataService.DTO
{
    public class SpecialRoles
    {
        public int UserId { get; set; }
        
        public RoleType RoleType { get; set; }
        public virtual Users User { get; set; }
    }
}
