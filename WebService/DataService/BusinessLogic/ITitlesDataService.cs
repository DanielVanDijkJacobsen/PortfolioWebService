using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DataService.BusinessLogic
{
    public interface ITitlesDataService
    {
        public Task<Titles> GetTitleById(object id);
        public Task<List<Titles>> GetAllTitles();
        public Task<List<Titles>> SearchForTitle(int? num, string searchString);
        public void RateTitle(UserRating rating);
        public Task<List<Titles>> GetPopularTitles(int num, string type);
        public Task<List<Comments>> GetCommentsByTitleId(string id);

        public Task<List<CastInfo>> SearchByName(string name);
        public Task<List<Casts>> GetAllCasts();
        public Task<List<TitleInfo>> GetTitleInfoByTitleId(string id);
        public Task<List<TitleAlias>> GetTitleAliasByTitleId(string id);
        public Task<List<TitleFormats>> GetTitleFormatByTitleId(string id);
        public Task<Comments> CreateComment(Comments entity);
        public Task<Comments> UpdateComment(int id, Comments comment);
        public Task<FlaggedComment> FlagComment(int id, FlaggedComment comment);
        public Task<List<FlaggedComment>> GetFlaggedComment(int userId, int commentId);
        public Task<FlaggedComment> DeleteFlaggedComment(int userId, int commentId);
        public Task<List<UserRating>> GetUserRatingByUserIdAndTitleId(int userId, string titleId);
        public Task<List<UserRating>> GetUserRatingByTitleId(string titleId);
        public Task<UserRating> CreateUserRating(UserRating entity);
        public Task<UserRating> UpdateUserRating(UserRating entity);
        public Task<UserRating> DeleteUserRating(UserRating entity);
        public Task<Bookmarks> CreateBookmark(Bookmarks entity);
        public Task<List<Bookmarks>> GetBookmark(string tid, int uid);
        public Task<Genres> GetGenreByTitleId(string id);
        public Task<Formats> GetFormatByTitleId(string id);
    }
}
