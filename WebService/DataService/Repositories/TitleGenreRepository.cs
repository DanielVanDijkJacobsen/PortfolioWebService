using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DMO;

namespace WebService.DataService.Repositories
{
    class TitleGenreRepository : GenericRepository<TitleGenres>
    {
        public TitleGenreRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<TitleGenres>> WhereByTitleId(string id)
        {
            return await Context.Set<TitleGenres>().Where(titleGenre => titleGenre.TitleId == id).ToListAsync();
        }
    }
}
