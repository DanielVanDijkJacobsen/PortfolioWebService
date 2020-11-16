using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DMO;
using WebService.Filters;

namespace WebService.DataService.Repositories
{
    class UserRatingRepository : GenericRepository<UserRating>
    {
        public UserRatingRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<UserRating>> WhereByUserId(int? id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<UserRating>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(userRating => userRating.UserId == id).ToListAsync();
            }
            return await Context.Set<UserRating>().Where(userRating => userRating.UserId == id).ToListAsync();
        }

        public async Task<List<UserRating>> WhereByTitleId(string id, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<UserRating>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(userRating => userRating.TitleId == id).ToListAsync();
            }
            return await Context.Set<UserRating>().Where(userRating => userRating.TitleId == id).ToListAsync();
        }

        public async Task<List<UserRating>> WhereByUserIdAndTitleId(int uid, string tid, PaginationFilter filter = null)
        {
            if (filter != null)
            {
                return await Context.Set<UserRating>().Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).Where(userRating => userRating.TitleId == tid && userRating.UserId == uid).ToListAsync();
            }
            return await Context.Set<UserRating>()
                .Where(userRating => userRating.TitleId == tid && userRating.UserId == uid).ToListAsync();
        }
    }
}
