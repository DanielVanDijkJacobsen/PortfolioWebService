using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;
using WebService.DataService.Repositories;

namespace WebService.DataService.BusinessLogic
{
    public class CastsDataService : ICastsDataService
    {
        private readonly CastsRepository _casts;
        private readonly CastInfoRepository _castInfo;
        private readonly CastProfessionRepository _castProfession;
        private readonly CastKnownForRepository _castKnownFor;
        private readonly NameRatingRepository _nameRating;

        public CastsDataService()
        {
            var context = new ImdbContext();
            _casts = new CastsRepository(context);
            _nameRating = new NameRatingRepository(context);
            _castInfo = new CastInfoRepository(context);
            _castProfession = new CastProfessionRepository(context);
            _castKnownFor = new CastKnownForRepository(context);
        }

        public async Task<List<Casts>> GetAllCasts()
        {
            return await _casts.ReadAll();
        }

        public async Task<List<CastInfo>> GetAllCastInfos()
        {
            return await _castInfo.ReadAll();
        }

        public async Task<List<CastProfession>> GetCastProfessionByCastId(string id)
        {
            return await _castProfession.WhereByCastId(id);
        }

        public async Task<List<CastKnownFor>> GetCastKnownForByCastId(string id)
        {
            return await _castKnownFor.WhereByCastId(id);
        }

        public async Task<List<CastInfo>> GetCastInfoByCastId(string id)
        {
            return await _castInfo.WhereByCastId(id);
        }

        public async Task<List<NameRating>> GetNameRatingByCastId(string id)
        {
            return await _nameRating.WhereByCastId(id);
        }

        public async Task<List<NameRating>> UpdateNameRating(string id)
        {
            return await _nameRating.UpdateNameRating(id);
        }

        public async Task<Casts> GetCastById(string id)
        {
            return await _casts.ReadById(id);
        }

        public async Task<CastInfo> GetCastInfoById(string id)
        {
            return await _castInfo.ReadById(id);
        }

        public async Task<List<Casts>> GetCastsByTitleId(string id)
        {
            return await _casts.WhereByTitleId(id);
        }
    }
}
