using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class CastKnownForRepository : GenericRepository<CastKnownFor>
    {
        public CastKnownForRepository(ImdbContext context) : base(context)
        {

        }
    }
}
