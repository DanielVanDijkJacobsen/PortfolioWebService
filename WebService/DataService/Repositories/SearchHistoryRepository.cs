using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class SearchHistoryRepository : GenericRepository<SearchHistory>
    {
        public SearchHistoryRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<SearchHistory>> WhereByUserId(int? id)
        {
            return await Context.Set<SearchHistory>().Where(searchHistory => searchHistory.UserId == id).ToListAsync();
        }
    }
}
