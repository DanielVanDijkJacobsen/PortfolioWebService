using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class TitleFormatRepository : GenericRepository<TitleFormats>
    {
        public TitleFormatRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<TitleFormats>> WhereByTitleId(object? id)
        {
            return await Context.Set<TitleFormats>().Where(titleFormat => titleFormat.TitleId == id).ToListAsync();
        }
    }
}
