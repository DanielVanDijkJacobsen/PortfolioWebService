using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebService.DataService.BusinessLogic;
using WebService.DataService.CustomTypes;
using WebService.DataService.DTO;
using WebService.DTOs;
using Xunit;
using Xunit.Abstractions;
using static Xunit.Assert;

namespace WebService.DataService.BusinessLogicTests
{
    public class Tests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public IUsersDataService Framework = new UserDataService();
        public ITitlesDataService Movie = new TitleDataService();
        public ICastsDataService Cast = new CastsDataService();

        public Tests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void FindUser()
        {
            var user = Framework.GetUserById(1).Result;
            Equal("Smed", user.Name);
        }

        [Fact]
        public void GetTitleById()
        {
            var title = Movie.GetTitleById("tt0125742").Result;
            Equal("FVVA: Femme, villa, voiture, argent", title.PrimaryTitle);
            //TODO::Add all relations readings
            Equal(1, title.TitleAlias.Count);
        }

        [Fact]
        public void SearchForTitle()
        {
            var title = Movie.SearchForTitle(1, "casino").Result;
            Equal("Casino Royale", title.First().PrimaryTitle);
            Equal("Casino Royale", title.First().OriginalTitle);
            Equal("Jacobo deja a un lado su venganza para proteger a Lucía", title.Last().PrimaryTitle);
            Equal("Jacobo deja a un lado su venganza para proteger a Lucía", title.Last().OriginalTitle);

            var searchHistory = Framework.GetSearchHistoryByUserId(1).Result;
            True(searchHistory.Count >= 1, "Expected actualCount to be greater than 1.");
        }

        [Fact]
        public void GetPopularMovies()
        {
            var title = Movie.GetPopularTitles(1, "movie").Result;
            Equal("The Dark Knight Rises", title.First().PrimaryTitle);
        }

        [Fact]
        public void GetPopularSeries()
        {
            var title = Movie.GetPopularTitles(1, "tvSeries").Result;
            Equal("Young Dylan", title.First().PrimaryTitle);
        }

        [Fact]
        public void RateTitle()
        {
            var userRating = new UserRating() { Score = 8, TitleId = "tt0125742", UserId = 1 };
            var newRating = Movie.RateTitle(userRating).Result;
            Equal(8, newRating.Score);

            userRating.Score = 9;
            var updatedRating = Framework.UpdateUserRating(userRating).Result;
            Equal(9, updatedRating.Score);

            var ratings = Movie.GetUserRatingByTitleId("tt0125742").Result;
            Equal(1, ratings.Count);

            var userRatinss = Movie.GetUserRatingByUserIdAndTitleId(1, "tt0125742").Result;
            Equal(1, userRatinss.Count);

            var userRatinssUsers = Framework.GetUserRatingsByUserId(1).Result;
            True(userRatinssUsers.Count >= 1, "Expected actualCount to be greater than 1.");

            var rating = Framework.DeleteUserRating(1, "tt0125742").Result;
            Equal(9, rating.Score);
        }

        [Fact]
        public void CreateComment()
        {
            var comment = new Comments() { Comment = "from tests", UserId = 1, TitleId = "tt0125742" };
            var rating = Framework.CreateComment(comment).Result;
            Equal("from tests", rating.Comment);

            var getComment = Framework.GetCommentById(rating.CommentId).Result;
            Equal("from tests", getComment.Comment);

            var getComments = Framework.GetCommentsByUserId(1).Result;
            True(getComments.Count >= 1, "Expected actualCount to be greater than 1.");
        }

        [Fact]
        public void CreateSubComment()
        {

            var commentId = Movie.GetCommentsByTitleId("tt0125742").Result.First().CommentId;
            var comment = new Comments() { Comment = "from tests sub comment", UserId = 1, TitleId = "tt0125742", ParentCommentId = commentId };
            var rating = Framework.CreateComment(comment).Result;
            Equal("from tests sub comment", rating.Comment);
        }

        [Fact]
        public void GetCommentsForTitle()
        {
            var comments = Movie.GetCommentsByTitleId("tt0125742").Result;
            True(comments.Count >= 1, "Expected actualCount to be greater than 1.");
        }

        [Fact]
        public void UpdateComment()
        {
            var commentId = Movie.GetCommentsByTitleId("tt0125742").Result.First().CommentId;
            var comment = new Comments() { Comment = "from tests updated", UserId = 1, TitleId = "tt0125742" }; ;
            var comments = Framework.UpdateComment(commentId, comment).Result;
            Equal("from tests updated", comments.Comment);
        }

        [Fact]
        public void DeleteComment()
        {
            var comment = new Comments() { Comment = "from tests", UserId = 1, TitleId = "tt0125742" };
            var rating = Framework.CreateComment(comment).Result;
            var comments = Framework.DeleteComment(rating.CommentId).Result;
        }

        [Fact]
        public void FlagCommentTests()
        {
            var newCommentId = Movie.GetCommentsByTitleId("tt0125742").Result.Last().CommentId;
            var newComment = new FlaggedComment() { CommentId = newCommentId, FlaggingUser = 1 };
            var flaggedComment = Framework.FlagComment(newComment).Result;
            Equal(newCommentId, flaggedComment.CommentId);

            var commentId = Movie.GetCommentsByTitleId("tt0125742").Result.Last().CommentId;
            var comment = new FlaggedComment() { CommentId = commentId, FlaggingUser = 1 };
            var comments = Framework.GetFlaggedComment(1, commentId).Result;
            Equal(commentId, comments.Last().CommentId);

            Framework.DeleteFlaggedComment(1, commentId);
        }


        [Fact]
        public void BookmarkTests()
        {
            var bookmark = new Bookmarks() { BookmarkType = BookmarkType.title, TypeId = "tt0125742", UserId = 1 };
            var bookmarks = Movie.CreateBookmark(bookmark).Result;
            Equal("tt0125742", bookmarks.TypeId);
            var getBookmarks = Movie.GetBookmark("tt0125742", 1).Result;
            Equal("tt0125742", getBookmarks.First().TypeId);
            var getBookmarksByUserId = Framework.GetBookmarksByUserId(1).Result;
            True(getBookmarksByUserId.Count >= 1, "Expected actualCount to be greater than 1.");
            Framework.DeleteBookmark(1, "tt0125742");
        }

        [Fact]
        public void GetGenreByTitleId()
        {
            var genre = Movie.GetGenreByTitleId("tt0125742").Result;
            Equal("", genre.Genre);
        }

        [Fact]
        public void GetFormatByTitleId()
        {
            var format = Movie.GetFormatByTitleId("tt6256914").Result;
            Equal("", format.Format);
        }


        [Fact]
        public void GetTitleInfoByTitleId()
        {
            var titleInfo = Movie.GetTitleInfoByTitleId("tt6256914").Result;
            Equal("tt6256914", titleInfo.First().TitleId);
        }

        [Fact]
        public void SearchForCast()
        {
            var cast = Cast.SearchCastByName("keanu").Result;
            Equal("Keanu Reeves", cast.First().Name);
        }
        
        [Fact]
        public void GetAllTitles()
        {
            var titles = Movie.GetAllTitles().Result;
            Equal("FVVA: Femme, villa, voiture, argent", titles.First().PrimaryTitle);
        }

        [Fact]
        public void GetUserByEmail()
        {
            var user = Framework.GetUserByEmail("Smedenergod@gmail.com").Result;
            Equal("Smed", user.Name);
        }
    }
}
