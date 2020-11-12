using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class CastKnownForRepository : GenericRepository<CastKnownFor>
    {
        public CastKnownForRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<CastKnownFor>> WhereByCastId(string id)
        {
            return await Context.CastKnownFor.Where(x => x.CastId == id).ToListAsync();
        }
    }
}
