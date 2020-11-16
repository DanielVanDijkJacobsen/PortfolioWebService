using WebService.DataService.DMO;

namespace WebService.DataService.Repositories
{
    class EpisodeRepository : GenericRepository<Episodes>
    {
        public EpisodeRepository(ImdbContext context) : base(context)
        {

        }
    }
}
