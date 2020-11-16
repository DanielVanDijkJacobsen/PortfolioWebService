using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DataService.DMO;
using WebService.DataService.Repositories;
using WebService.Filters;

namespace WebService.DataService.BusinessLogic
{
    public class UserDataService : IUsersDataService
    {
        private readonly UserRepository _users;
        private readonly SpecialRolesRepository _specialRoles;
        private readonly SearchHistoryRepository _searchHistory;
        private readonly CommentsRepository _comments;
        private readonly BookmarkRepository _bookmarks;
        private readonly FlaggedCommentsRepository _flaggedComments;
        private readonly UserRatingRepository _userRatings;

        public UserDataService()
        {
            ImdbContext context = new ImdbContext();
            _users = new UserRepository(context);
            _bookmarks = new BookmarkRepository(context);
            _comments = new CommentsRepository(context);
            _searchHistory = new SearchHistoryRepository(context);
            _specialRoles = new SpecialRolesRepository(context);
            _userRatings = new UserRatingRepository(context);
            _flaggedComments = new FlaggedCommentsRepository(context);
        }

        public async Task<Users> GetUserById(object id)
        {
            return await _users.ReadById(id);
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _users.ReadAll();
        }

        public async Task<Users> CreateUser(Users entity)
        {
            entity.LastAccess = DateTime.Now;
            entity.AccountCreation = DateTime.Now;
            return await _users.Create(entity);
        }

        public async Task<Users> UpdateUser(object id, Users entity)
        {
            var user = _users.ReadById(id).Result;
            if (entity.Name != null)
                user.Name = entity.Name;
            if (entity.Password != null)
                user.Password = entity.Password;
            if (entity.Salt != null)
                user.Salt = entity.Salt;
            user.DateOfBirth = entity.DateOfBirth;
            if (entity.Email != null)
                user.Email = entity.Email;
            if (entity.Nickname != null)
                user.Nickname = entity.Nickname;
            return await _users.Update(user);
        }

        public async Task<Users> DeleteUser(object id)
        {
            var user = _users.ReadById(id).Result;
            return await _users.Delete(user);
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            return await _users.ReadByEmail(email);
        }

        public async Task<Users> ValidateUserByPassword(string email, string password)
        {
            return await _users.ValidatePassword(email, password);
        }

        public async Task<Comments> GetCommentById(int id)
        {
            return await _comments.ReadById(id);
        }

        public async Task<List<Comments>> GetCommentsByUserId(int id, PaginationFilter filter = null)
        {
            return await _comments.WhereByUserId(id, filter);
        }

        public async Task<List<Bookmarks>> GetBookmarksByUserId(int id, PaginationFilter filter = null)
        {
            return await _bookmarks.WhereByUserId(id, filter);
        }
        
        public async Task<Comments> DeleteComment(int id)
        {
            var entity = _comments.ReadById(id).Result;
            return await _comments.Delete(entity);
        }
        
        public async Task<List<UserRating>> GetUserRatingsByUserId(int id, PaginationFilter filter = null)
        {
            return await _userRatings.WhereByUserId(id, filter);
        }

        public async Task<Bookmarks> DeleteBookmark(int uid, string tid)
        {
            var bookmark = await _bookmarks.WhereByTitleAndUserId(uid, tid);
            return await _bookmarks.Delete(bookmark.First());
        }

        public async Task<List<SpecialRoles>> GetSpecialRolesByUserId(int id)
        {
            return await _specialRoles.WhereByUserId(id);
        }

        public async Task<List<SpecialRoles>> DeleteSpecialRoleByUserId(int id)
        {
            return await _specialRoles.WhereByUserId(id);
        }

        public async Task<SpecialRoles> CreateSpecialRole(SpecialRoles entity)
        {
            return await _specialRoles.Create(entity);
        }

        public async Task<SpecialRoles> UpdateSpecialRole(SpecialRoles entity)
        {
            return await _specialRoles.Update(entity);
        }

        public async Task<List<SearchHistory>> GetSearchHistoryByUserId(int id, PaginationFilter filter = null)
        {
            return await _searchHistory.WhereByUserId(id, filter);
        }

        public async Task<UserRating> UpdateUserRating(UserRating entity)
        {
            return await _userRatings.Update(entity);
        }

        public async Task<UserRating> DeleteUserRating(int userId, string titleId)
        {
            var userRating = await _userRatings.ReadById(new object[] {userId, titleId});
            return await _userRatings.Delete(userRating);
        }

        public async Task<Comments> CreateComment(Comments entity)
        {
            entity.CommentTime = DateTime.Now;
            await _comments.Create(entity);
            return _comments.WhereByUserId(entity.UserId).Result.Last();
        }

        public async Task<Comments> UpdateComment(int id, Comments comment)
        {
            var entity = _comments.ReadById(id).Result;
            entity.Comment = comment.Comment;
            entity.CommentTime = comment.CommentTime;
            entity.IsEdited = true;
            return await _comments.Update(entity);
        }

        public async Task<FlaggedComment> FlagComment(FlaggedComment comment)
        {

            return await _flaggedComments.Create(comment);
        }

        public async Task<List<FlaggedComment>> GetFlaggedComment(int userId, int commentId)
        {
            return await _flaggedComments.WhereByUserIdAndCommentId(userId, commentId);
        }

        public async Task<FlaggedComment> DeleteFlaggedComment(int userId, int commentId)
        {
            var flaggedComment = await GetFlaggedComment(userId, commentId);
            return await _flaggedComments.Delete(flaggedComment.First());
        }
    }
}
