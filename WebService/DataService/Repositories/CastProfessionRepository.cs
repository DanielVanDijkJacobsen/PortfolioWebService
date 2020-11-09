using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class CastProfessionRepository : GenericRepository<CastProfession>
    {
        public CastProfessionRepository(ImdbContext context) : base(context)
        {

        }
    }
}
