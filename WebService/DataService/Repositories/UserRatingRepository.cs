using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class UserRatingRepository : GenericRepository<UserRating>
    {
        public UserRatingRepository(ImdbContext context) : base(context)
        {

        }

        public async Task<List<UserRating>> WhereByUserId(int? id)
        {
            return await Context.Set<UserRating>().Where(userRating => userRating.UserId == id).ToListAsync();
        }

        public async Task<List<UserRating>> WhereByTitleId(string id)
        {
            return await Context.Set<UserRating>().Where(userRating => userRating.TitleId == id).ToListAsync();
        }

        public async Task<List<UserRating>> WhereByUserIdAndTitleId(int uid, string tid)
        {
            return await Context.Set<UserRating>()
                .Where(userRating => userRating.TitleId == tid && userRating.UserId == uid).ToListAsync();
        }
    }
}
