using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DMO;

namespace WebService.DataService.Repositories
{
    class CastProfessionRepository : GenericRepository<CastProfession>
    {
        public CastProfessionRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<CastProfession>> WhereByCastId(string id)
        {
            return await Context.CastProfession.Where(x => x.CastId == id).ToListAsync();
        }
    }
}
