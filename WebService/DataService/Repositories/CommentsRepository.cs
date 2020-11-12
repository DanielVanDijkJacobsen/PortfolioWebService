using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    public class CommentsRepository : GenericRepository<Comments>
    {
        public CommentsRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<Comments>> WhereByUserId(int? id)
        {
            return await Context.Set<Comments>().Where(comment => comment.UserId == id).ToListAsync();
        }

        public async Task<List<Comments>> WhereByTitleId(string id)
        {
            return await Context.Set<Comments>().Where(Comments => Comments.TitleId == id).ToListAsync();
        }
    }
}
