using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class CastInfoRepository : GenericRepository<CastInfo>
    {
        public CastInfoRepository(ImdbContext context) : base(context)
        {

        }
    }
}
