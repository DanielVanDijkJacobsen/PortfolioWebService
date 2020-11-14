using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;
using WebService.Filters;

namespace WebService.DataService.BusinessLogic
{
    public interface ICastsDataService
    {
        public Task<Casts> GetCastById(string id, int ordering);
        public Task<CastInfo> GetCastInfoById(string id);
        public Task<List<Casts>> GetAllCasts(PaginationFilter paginationFilter = null);
        public Task<int> CountAll();
        public Task<List<CastInfo>> GetAllCastInfos();
        public Task<List<CastProfession>> GetCastProfessionByCastId(string id);
        public Task<List<CastKnownFor>> GetCastKnownForByCastId(string id);
        public Task<List<CastInfo>> GetCastInfoByCastId(string id);
        public Task<List<NameRating>> GetNameRatingByCastId(string id);
        public Task<List<NameRating>> UpdateNameRating(string id);
        public Task<List<Casts>> GetCastsByTitleId(string id);
        public Task<List<CastInfo>> SearchCastByName(string name);
    }
}
