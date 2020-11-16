using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DMO;

namespace WebService.DataService.Repositories
{
    class CastsRepository : GenericRepository<Casts>
    {
        public CastsRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Casts>> WhereByTitleId(string id)
        {
            return await Context.Set<Casts>().Where(casts => casts.TitleId == id).ToListAsync();
        }
    }
}
