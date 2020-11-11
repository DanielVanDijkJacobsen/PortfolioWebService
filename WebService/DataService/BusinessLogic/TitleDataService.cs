using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;
using WebService.DataService.Repositories;

namespace WebService.DataService.BusinessLogic
{
    public class TitleDataService : ITitlesDataService
    {
        private readonly TitleRepository _titles;
        private readonly CastsRepository _casts;
        private readonly CastInfoRepository _castInfo;
        private readonly IGenericRepository<CastProfession> _castProfession;
        private readonly IGenericRepository<CastKnownFor> _castKnownFor;
        private readonly IGenericRepository<UserRating> _userRating;
        private readonly IGenericRepository<TitleFormats> _titleFormat;
        private readonly IGenericRepository<TitleGenres> _titleGenre;
        private readonly IGenericRepository<TitleAlias> _titleAlias;
        private readonly IGenericRepository<TitleInfo> _titleInfo;
        private readonly IGenericRepository<Episodes> _episodes;
        private readonly CommentsRepository _comments;

        public TitleDataService()
        {
            var context = new ImdbContext();
            _titles = new TitleRepository(context);
            _casts = new CastsRepository(context);
            _castInfo = new CastInfoRepository(context);
            _castProfession = new GenericRepository<CastProfession>(context);
            _castKnownFor = new GenericRepository<CastKnownFor>(context);
            _userRating = new GenericRepository<UserRating>(context);
            _titleFormat = new GenericRepository<TitleFormats>(context);
            _titleGenre = new GenericRepository<TitleGenres>(context);
            _titleAlias = new GenericRepository<TitleAlias>(context);
            _titleInfo = new GenericRepository<TitleInfo>(context);
            _episodes = new GenericRepository<Episodes>(context);
            _comments = new CommentsRepository(context);
        }


        public async Task<Titles> GetTitleById(object id)
        {
            return await _titles.ReadById(id);
        }

        public async Task<List<Titles>> GetPopularTitles(int num, string type)
        {
            return await _titles.GetPopularTitles(num, type);
        }

        public async void RateTitle(UserRating rating)
        {
            await _userRating.Create(rating);
            return;
        }

        public async Task<List<Comments>> GetCommentsByTitleId(string id)
        {
            return await _comments.WhereByTitleId(id);
        }

        public async Task<List<Casts>> GetCastsByTitleId(string id)
        {
            return await _casts.WhereByTitleId(id);
        }

        public async Task<List<Titles>> SearchForTitle(int? num, string searchString)
        {
            return await _titles.SearchForTitle(num, searchString);
        }

        public async Task<List<Episodes>> GetAllEpisodes()
        {
            return await _episodes.ReadAll();
        }

        public async Task<Episodes> UpdateEpisode(Episodes entity)
        {
            return await _episodes.Update(entity);
        }

        public async Task<Episodes> DeleteEpisode(Episodes entity)
        {
            return await _episodes.Delete(entity);
        }

        public async Task<Episodes> CreateEpisode(Episodes entity)
        {
            return await _episodes.Create(entity);
        }

        public async Task<List<Titles>> GetAllTitles()
        {
            return await _titles.ReadAll();
        }

        public async Task<Titles> UpdateTitle(Titles entity)
        {
            return await _titles.Update(entity);
        }

        public async Task<Titles> DeleteTitle(Titles entity)
        {
            return await _titles.Delete(entity);
        }

        public async Task<Titles> CreateTitle(Titles entity)
        {
            return await _titles.Create(entity);
        }

        public async Task<List<UserRating>> GetAllUserRatings()
        {
            return await _userRating.ReadAll();
        }

        public async Task<UserRating> UpdateUserRating(UserRating entity)
        {
            return await _userRating.Update(entity);
        }

        public async Task<UserRating> DeleteUserRating(UserRating entity)
        {
            return await _userRating.Delete(entity);
        }

        public async Task<UserRating> CreateUserRating(UserRating entity)
        {
            return await _userRating.Create(entity);
        }

        public async Task<CastProfession> CreateCastProfession(CastProfession entity)
        {
            return await _castProfession.Create(entity);
        }

        public async Task<CastInfo> GetCastInfoById(object id)
        {
            return await _castInfo.ReadById(id);
        }

        public async Task<List<CastInfo>> GetAllCastInfos()
        {
            return await _castInfo.ReadAll();
        }

        public async Task<CastInfo> UpdateCastInfo(CastInfo entity)
        {
            return await _castInfo.Update(entity);
        }

        public async Task<CastInfo> DeleteCastInfo(CastInfo entity)
        {
            return await _castInfo.Delete(entity);
        }

        public async Task<CastInfo> CreateCastInfo(CastInfo entity)
        {
            return await _castInfo.Create(entity);
        }

        public async Task<Casts> GetCastById(object id)
        {
            return await _casts.ReadById(id);
        }

        public async Task<Casts> CreateCast(Casts entity)
        {
            return await _casts.Create(entity);
        }

        public async Task<TitleInfo> GetTitleInfoById(object id)
        {
            return await _titleInfo.ReadById(id);
        }

        public async Task<TitleInfo> CreateTitleInfo(TitleInfo entity)
        {
            return await _titleInfo.Create(entity);
        }

        public async Task<TitleAlias> GetTitleAliasById(object id)
        {
            return await _titleAlias.ReadById(id);
        }

        public async Task<TitleAlias> CreateTitleAlias(TitleAlias entity)
        {
            return await _titleAlias.Create(entity);
        }

        public async Task<TitleFormats> GetTitleFormatById(object id)
        {
            return await _titleFormat.ReadById(id);
        }

        public async Task<TitleFormats> CreateTitleFormats(TitleFormats entity)
        {
            return await _titleFormat.Create(entity);
        }

        public async Task<TitleGenres> GetTitleGenreById(object id)
        {
            return await _titleGenre.ReadById(id);
        }

        public async Task<CastKnownFor> CreateCastKnownFor(CastKnownFor entity)
        {
            return await _castKnownFor.Create(entity);
        }

        public async Task<Episodes> GetEpisodeById(object id)
        {
            return await _episodes.ReadById(id);
        }

        public async Task<UserRating> GetUserRatingById(object id)
        {
            return await _userRating.ReadById(id);
        }

        public async Task<List<Casts>> GetAllCasts()
        {
            return await _casts.ReadAll();
        }

        public async Task<List<CastInfo>> SearchByName(string name)
        {
            return await _castInfo.SearchByName(name);
        }

        public async Task<Casts> UpdateCast(Casts entity)
        {
            return await _casts.Update(entity);
        }

        public async Task<Casts> DeleteCast(Casts entity)
        {
            return await _casts.Delete(entity);
        }

        public async Task<List<TitleInfo>> GetAllTitleInfos()
        {
            return await _titleInfo.ReadAll();
        }

        public async Task<TitleInfo> UpdateTitleInfo(TitleInfo entity)
        {
            return await _titleInfo.Update(entity);
        }

        public async Task<TitleInfo> DeleteTitleInfo(TitleInfo entity)
        {
            return await _titleInfo.Delete(entity);
        }

        public async Task<List<TitleAlias>> GetAllTitleAlias()
        {
            return await _titleAlias.ReadAll();
        }

        public async Task<TitleAlias> UpdateTitleAlias(TitleAlias entity)
        {
            return await _titleAlias.Update(entity);
        }

        public async Task<TitleAlias> DeleteTitleAlias(TitleAlias entity)
        {
            return await _titleAlias.Delete(entity);
        }

        public async Task<List<TitleFormats>> GetAllTitleFormats()
        {
            return await _titleFormat.ReadAll();
        }

        public async Task<TitleFormats> UpdateTitleFormats(TitleFormats entity)
        {
            return await _titleFormat.Update(entity);
        }

        public async Task<TitleFormats> DeleteTitleFormats(TitleFormats entity)
        {
            return await _titleFormat.Delete(entity);
        }

        public async Task<List<TitleGenres>> GetAllTitleGenres()
        {
            return await _titleGenre.ReadAll();
        }

        public async Task<TitleGenres> UpdateTitleGenre(TitleGenres entity)
        {
            return await _titleGenre.Update(entity);
        }

        public async Task<TitleGenres> DeleteTitleGenre(TitleGenres entity)
        {
            return await _titleGenre.Delete(entity);
        }

        public async Task<TitleGenres> CreateTitleGenre(TitleGenres entity)
        {
            return await _titleGenre.Create(entity);
        }

        public async Task<CastProfession> GetCastProfessionById(object id)
        {
            return await _castProfession.ReadById(id);
        }

        public async Task<List<CastProfession>> GetAllCastProfessions()
        {
            return await _castProfession.ReadAll();
        }

        public async Task<CastProfession> UpdateCastProfession(CastProfession entity)
        {
            return await _castProfession.Update(entity);
        }

        public async Task<CastProfession> DeleteCastProfession(CastProfession entity)
        {
            return await _castProfession.Delete(entity);
        }

        public async Task<CastKnownFor> GetCastKnownForById(object id)
        {
            return await _castKnownFor.ReadById(id);
        }

        public async Task<List<CastKnownFor>> GetAllCastKnownFor()
        {
            return await _castKnownFor.ReadAll();
        }

        public async Task<CastKnownFor> UpdateCastKnownFor(CastKnownFor entity)
        {
            return await _castKnownFor.Update(entity);
        }

        public async Task<CastKnownFor> DeleteCastKnownFor(CastKnownFor entity)
        {
            return await _castKnownFor.Delete(entity);
        }
    }
}
