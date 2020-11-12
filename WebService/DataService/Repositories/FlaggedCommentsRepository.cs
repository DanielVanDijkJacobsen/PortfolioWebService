using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class FlaggedCommentsRepository : GenericRepository<FlaggedComment>
    {
        public FlaggedCommentsRepository(ImdbContext context) : base(context)
        {

        }

        public async void FlagComment(FlaggedComment entity)
        {
            await Context.FlaggedComments.AddAsync(entity);
        }
    }
}
