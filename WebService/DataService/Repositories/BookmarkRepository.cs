using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class BookmarkRepository : GenericRepository<Bookmarks>
    {
        public BookmarkRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Bookmarks>> WhereByUserId(int? id)
        {
            return await Context.Set<Bookmarks>().Where(bookmark => bookmark.UserId == id).ToListAsync();
        }

        public async Task<List<Bookmarks>> WhereByTitleId(object? id)
        {
            return await Context.Set<Bookmarks>().Where(bookmark => bookmark.TypeId == id).ToListAsync();
        }
    }
}
