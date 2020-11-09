using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    public class TitleRepository : GenericRepository<Titles>
    {
        public TitleRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Titles>> SearchForTitle(int num, string searchString)
        {
            return await Context.Titles.FromSqlRaw("SELECT * FROM string_search({0}, {1})", num, searchString).ToListAsync();
        }
    }
}
