using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class SpecialRolesRepository : GenericRepository<SpecialRoles>
    {
        public SpecialRolesRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<SpecialRoles>> WhereByUserId(int? id)
        {
            return await Context.Set<SpecialRoles>().Where(specialRoles => specialRoles.UserId == id).ToListAsync();
        }
    }
}
