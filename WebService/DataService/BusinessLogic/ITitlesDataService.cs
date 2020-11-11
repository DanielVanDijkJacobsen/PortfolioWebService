using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DataService.BusinessLogic
{
    public interface ITitlesDataService
    {
        //Titles
        public Task<Titles> GetTitleById(object id);
        public Task<List<Titles>> GetAllTitles();
        public Task<Titles> UpdateTitle(Titles entity);
        public Task<Titles> DeleteTitle(Titles entity);
        public Task<Titles> CreateTitle(Titles entity);
        public Task<List<Titles>> SearchForTitle(int? num, string searchString);
        public void RateTitle(UserRating rating);

        public Task<List<Titles>> GetPopularTitles(int num, string type);



        //Comments
        public Task<List<Comments>> GetCommentsByTitleId(string id);

        //Casts
        public Task<Casts> GetCastById(object id);
        public Task<List<Casts>> GetAllCasts();
        public Task<List<CastInfo>> SearchByName(string name);
        public Task<Casts> UpdateCast(Casts entity);
        public Task<Casts> DeleteCast(Casts entity);
        public Task<Casts> CreateCast(Casts entity);
        public Task<List<Casts>> GetCastsByTitleId(string id);

        //TitleInfo
        public Task<TitleInfo> GetTitleInfoById(object id);
        public Task<List<TitleInfo>> GetAllTitleInfos();
        public Task<TitleInfo> UpdateTitleInfo(TitleInfo entity);
        public Task<TitleInfo> DeleteTitleInfo(TitleInfo entity);
        public Task<TitleInfo> CreateTitleInfo(TitleInfo entity);

        //TitleAlias
        public Task<TitleAlias> GetTitleAliasById(object id);
        public Task<List<TitleAlias>> GetAllTitleAlias();
        public Task<TitleAlias> UpdateTitleAlias(TitleAlias entity);
        public Task<TitleAlias> DeleteTitleAlias(TitleAlias entity);
        public Task<TitleAlias> CreateTitleAlias(TitleAlias entity);

        //TitleFormat
        public Task<TitleFormats> GetTitleFormatById(object id);
        public Task<List<TitleFormats>> GetAllTitleFormats();
        public Task<TitleFormats> UpdateTitleFormats(TitleFormats entity);
        public Task<TitleFormats> DeleteTitleFormats(TitleFormats entity);
        public Task<TitleFormats> CreateTitleFormats(TitleFormats entity);

        //TitleGenre
        public Task<TitleGenres> GetTitleGenreById(object id);
        public Task<List<TitleGenres>> GetAllTitleGenres();
        public Task<TitleGenres> UpdateTitleGenre(TitleGenres entity);
        public Task<TitleGenres> DeleteTitleGenre(TitleGenres entity);
        public Task<TitleGenres> CreateTitleGenre(TitleGenres entity);

        //CastProfession
        public Task<CastProfession> GetCastProfessionById(object id);
        public Task<List<CastProfession>> GetAllCastProfessions();
        public Task<CastProfession> UpdateCastProfession(CastProfession entity);
        public Task<CastProfession> DeleteCastProfession(CastProfession entity);
        public Task<CastProfession> CreateCastProfession(CastProfession entity);

        //CastInfo
        public Task<CastInfo> GetCastInfoById(object id);
        public Task<List<CastInfo>> GetAllCastInfos();
        public Task<CastInfo> UpdateCastInfo(CastInfo entity);
        public Task<CastInfo> DeleteCastInfo(CastInfo entity);
        public Task<CastInfo> CreateCastInfo(CastInfo entity);

        //CastKnownFor
        public Task<CastKnownFor> GetCastKnownForById(object id);
        public Task<List<CastKnownFor>> GetAllCastKnownFor();
        public Task<CastKnownFor> UpdateCastKnownFor(CastKnownFor entity);
        public Task<CastKnownFor> DeleteCastKnownFor(CastKnownFor entity);
        public Task<CastKnownFor> CreateCastKnownFor(CastKnownFor entity);

        //Episodes
        public Task<Episodes> GetEpisodeById(object id);
        public Task<List<Episodes>> GetAllEpisodes();
        public Task<Episodes> UpdateEpisode(Episodes entity);
        public Task<Episodes> DeleteEpisode(Episodes entity);
        public Task<Episodes> CreateEpisode(Episodes entity);

        //UserRating
        public Task<UserRating> GetUserRatingById(object id);
        public Task<List<UserRating>> GetAllUserRatings();
        public Task<UserRating> UpdateUserRating(UserRating entity);
        public Task<UserRating> DeleteUserRating(UserRating entity);
        public Task<UserRating> CreateUserRating(UserRating entity);
    }
}
