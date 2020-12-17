using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DMO;
using WebService.Filters;

namespace WebService.DataService.BusinessLogic
{
    public interface IUsersDataService
    {
        public Task<Users> GetUserById(int? id);
        public Task<List<Users>> GetAllUsers();
        public Task<Users> CreateUser(Users entity);
        public Task<Users> UpdateUser(object id, Users entity);
        public Task<Users> DeleteUser(object id);
        public Task<Users> GetUserByEmail(string email);
        public Task<Users> ValidateUserByPassword(string email, string password);
        public Task<List<Comments>> GetCommentsByUserId(int id, PaginationFilter filter = null);
        public Task<Comments> GetCommentById(int id);
        public Task<Comments> DeleteComment(int id);
        public Task<List<UserRating>> GetUserRatingsByUserId(int id, PaginationFilter filter = null);
        public Task<Bookmarks> DeleteBookmark(int uid, string tid);
        public Task<List<Bookmarks>> GetBookmarksByUserId(int id, PaginationFilter filter = null);
        public Task<List<SpecialRoles>> GetSpecialRolesByUserId(int id);
        public Task<List<SpecialRoles>> DeleteSpecialRoleByUserId(int id);
        public Task<SpecialRoles> CreateSpecialRole(SpecialRoles entity);
        public Task<SpecialRoles> UpdateSpecialRole(SpecialRoles entity);
        public Task<List<SearchHistory>> GetSearchHistoryByUserId(int id, PaginationFilter filter = null);
        public Task<Comments> CreateComment(Comments entity);
        public Task<Comments> UpdateComment(int id, Comments comment);
        public Task<FlaggedComment> FlagComment(FlaggedComment comment);
        public Task<List<FlaggedComment>> GetFlaggedComment(int userId, int commentId);
        public Task<FlaggedComment> DeleteFlaggedComment(int userId, int commentId);
        public Task<UserRating> UpdateUserRating(UserRating entity);
        public Task<UserRating> DeleteUserRating(int userId, string titleId);
    }
}
