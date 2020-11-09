using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class EpisodeRepository : GenericRepository<Episodes>
    {
        public EpisodeRepository(ImdbContext context) : base(context)
        {

        }
    }
}
