using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebService.DataService.DTO;
using WebService.DataService.Repositories;

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

        public UserDataService()
        {
            ImdbContext context = new ImdbContext();
            _users = new UserRepository(context);
            _bookmarks = new BookmarkRepository(context);
            _comments = new CommentsRepository(context);
            _searchHistory = new SearchHistoryRepository(context);
            _specialRoles = new SpecialRolesRepository(context);
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

        public async Task<Comments> GetCommentById(object id)
        {
            return await _comments.ReadById(id);
        }

        public async Task<List<Comments>> GetCommentsByUserId(int id)
        {
            return await _comments.WhereByUserId(id);
        }

        public async Task<List<Bookmarks>> GetBookmarksByUserId(int id)
        {
            return await _bookmarks.WhereByUserId(id);
        }

        public async Task<List<Comments>> GetAllComments()
        {
            return await _comments.ReadAll();
        }

        public async Task<Comments> UpdateComment(object id, Comments entity)
        {
            var _entity = _comments.ReadById(id).Result;
            _entity.Comment = entity.Comment;
            _entity.CommentTime = entity.CommentTime;
            return await _comments.Update(_entity);
        }

        public async Task<Comments> DeleteComment(object id)
        {
            var entity = _comments.ReadById(id).Result;
            return await _comments.Delete(entity);
        }

        public async void FlagComment(FlaggedComment entity)
        {
            _flaggedComments.FlagComment(new FlaggedComment { CommentId = entity.CommentId, UserId = entity.UserId });
        }

        public async Task<Bookmarks> DeleteBookmark(object id)
        {
            var bookmark = await _bookmarks.ReadById(id);
            return await _bookmarks.Delete(bookmark);
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

        public async Task<List<SearchHistory>> GetSearchHistoryByUserId(int id)
        {
            return await _searchHistory.WhereByUserId(id);
        }
    }
}
