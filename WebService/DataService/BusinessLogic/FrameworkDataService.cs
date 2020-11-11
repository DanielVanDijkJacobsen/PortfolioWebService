using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebService.DataService.DTO;
using WebService.DataService.Repositories;

namespace WebService.DataService.BusinessLogic
{
    public class FrameworkDataService : IFrameworkDataService
    {
        private readonly UserRepository _users;
        private readonly GenericRepository<SpecialRoles> _specialRoles;
        private readonly GenericRepository<SearchHistory> _searchHistory;
        private readonly GenericRepository<Comments> _comments;
        private readonly GenericRepository<Bookmarks> _bookmarks;
        private readonly FlaggedCommentsRepository _flaggedComments;

        public FrameworkDataService()
        {
            ImdbContext context = new ImdbContext();
            _users = new UserRepository(context);
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
            if (entity.DateOfBirth != null)
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
            var _entity = _comments.ReadById(id).Result;
            return await _comments.Delete(_entity);
        }

        public async Task<Comments> CreateComment(Comments entity)
        {
            entity.CommentTime = DateTime.Now;
            return await _comments.Create(entity);
        }

        public async void FlagComment(FlaggedComment entity)
        {
            var _comment = new FlaggedComment();
            _comment.CommentId = entity.CommentId;
            _comment.UserId = entity.UserId;
            _flaggedComments.FlagComment(_comment);
            return;
        }

        public async Task<Bookmarks> DeleteBookmark(object id)
        {
            var bookmark = await _bookmarks.ReadById(id);
            return await _bookmarks.Delete(bookmark);
        }

        public async Task<Bookmarks> CreateBookmark(Bookmarks entity)
        {
            return await _bookmarks.Create(entity);
        }
    }
}
