using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;
using WebService.Filters;

namespace WebService.DataService.Repositories
{
    class BookmarkRepository : GenericRepository<Bookmarks>
    {
        public BookmarkRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Bookmarks>> WhereByUserId(int? id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<Bookmarks>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(bookmark => bookmark.UserId == id).ToListAsync();
            }
            return await Context.Set<Bookmarks>().Where(bookmark => bookmark.UserId == id).ToListAsync();
        }

        public async Task<List<Bookmarks>> WhereByTitleId(string id)
        {
            return await Context.Set<Bookmarks>().Where(bookmark => bookmark.TypeId == id).ToListAsync();
        }

        public async Task<List<Bookmarks>> WhereByTitleAndUserId(int uid, string tid)
        {
            return await Context.Set<Bookmarks>()
                .Where(bookmarks => bookmarks.UserId == uid && bookmarks.TypeId == tid).ToListAsync();
        }
    }
}
