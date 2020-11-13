using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DataService.BusinessLogic
{
    public interface IUsersDataService
    {
        public Task<Users> GetUserById(object id);
        public Task<List<Users>> GetAllUsers();
        public Task<Users> CreateUser(Users entity);
        public Task<Users> UpdateUser(object id, Users entity);
        public Task<Users> DeleteUser(object id);
        public Task<Users> GetUserByEmail(string email);
        public Task<Users> ValidateUserByPassword(string email, string password);
        public Task<List<Comments>> GetCommentsByUserId(int id);
        public Task<Comments> GetCommentById(int id);
        public Task<Comments> UpdateComment(object id, Comments entity);
        public Task<Comments> DeleteComment(int id);
        public void FlagComment(FlaggedComment entity);
        public Task<Bookmarks> DeleteBookmark(object id);
        public Task<List<UserRating>> GetUserRatingsByUserId(int id);
        public Task<Bookmarks> DeleteBookmark(int uid, string tid);
        public Task<List<Bookmarks>> GetBookmarksByUserId(int id);
        public Task<List<SpecialRoles>> GetSpecialRolesByUserId(int id);
        public Task<List<SearchHistory>> GetSearchHistoryByUserId(int id);
    }
}
