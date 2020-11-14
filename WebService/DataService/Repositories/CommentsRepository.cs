using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;
using WebService.Filters;

namespace WebService.DataService.Repositories
{
    public class CommentsRepository : GenericRepository<Comments>
    {
        public CommentsRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Comments>> WhereByUserId(int? id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<Comments>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(comments => comments.UserId == id).ToListAsync();
            }
            return await Context.Set<Comments>().Where(comments => comments.UserId == id).ToListAsync();
        }

        public async Task<List<Comments>> WhereByTitleId(string id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<Comments>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(comments => comments.TitleId == id).ToListAsync();
            }
            return await Context.Set<Comments>().Where(comments => comments.TitleId == id).ToListAsync();
        }

    }
}
