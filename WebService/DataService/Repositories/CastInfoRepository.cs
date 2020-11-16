using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DMO;

namespace WebService.DataService.Repositories
{
    class CastInfoRepository : GenericRepository<CastInfo>
    {
        public CastInfoRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<CastInfo>> SearchByName(string name)
        {
            return await Context.Set<CastInfo>().Where(casts => casts.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<List<CastInfo>> WhereByCastId(string id)
        {
            return await Context.CastInfo.Where(x => x.CastId == id).ToListAsync();
        }
    }
}
