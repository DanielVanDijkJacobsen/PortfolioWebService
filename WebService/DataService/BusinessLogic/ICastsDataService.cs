using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DataService.BusinessLogic
{
    public interface ICastsDataService
    {
        public Task<Casts> GetCastById(object id);
        public Task<List<Casts>> GetAllCasts();
        public Task<List<CastProfession>> GetCastProfessionByCastId(string id);
        public Task<List<CastKnownFor>> GetCastKnownForByCastId(string id);
        public Task<List<CastInfo>> GetCastInfoByCastId(string id);
        public Task<List<NameRating>> GetNameRatingByCastId(string id);
        public Task<List<NameRating>> UpdateNameRating(string id);
    }
}
