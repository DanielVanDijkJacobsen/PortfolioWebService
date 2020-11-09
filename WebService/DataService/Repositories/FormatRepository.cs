using WebService.DataService.DTO;

namespace WebService.DataService.Repositories
{
    class FormatRepository : GenericRepository<Formats>
    {
        public FormatRepository(ImdbContext context) : base(context)
        {

        }
    }
}
