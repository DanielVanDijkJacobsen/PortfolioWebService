using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;

namespace WebService.DataService.BusinessLogic
{
    public interface IFrameworkDataService
    {
        //Users
        public Task<Users> GetUserById(object id);
        public Task<List<Users>> GetAllUsers();
        public Task<Users> CreateUser(Users entity);
        public Task<Users> UpdateUser(object id, Users entity);
        public Task<Users> DeleteUser(object id);
        public Task<Users> GetUserByEmail(string email);
        public Task<Users> ValidateUserByPassword(string email, string password);

        //Comments
        public Task<Comments> GetCommentById(object id);
        public Task<List<Comments>> GetAllComments();
        public Task<Comments> UpdateComment(object id, Comments entity);
        public Task<Comments> DeleteComment(object id);
        public Task<Comments> CreateComment(Comments entity);

        public void FlagComment(FlaggedComment entity);

        //Bookmarks
        public Task<Bookmarks> DeleteBookmark(object id);
        public Task<Bookmarks> CreateBookmark(Bookmarks entity);

    }
}
