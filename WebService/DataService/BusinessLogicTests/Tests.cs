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


        //WebServiceTests

        ////Users
        //private const string UsersApi = "https://localhost:5001/api/users";
        //[Fact]
        //public void WebServiceGetAllUsers()
        //{
        //    var loginUser = new UserForCreateOrUpdateDto();
        //    loginUser.Email = "Smedenergod2@gmail.com";
        //    loginUser.Name = "Smed2";
        //    loginUser.Password = "Smed2";
        //    loginUser.Nickname = "Smed2";
        //    var url = String.Concat(UsersApi, "/login");
        //    var (dataCreate, statusCodeCreate) = PostData(UsersApi, loginUser);
        //    Equal("Ok", statusCodeCreate.ToString());
        //    var (dataLogin, statusLogin) = PostData(url, loginUser);
        //    Equal("Ok", statusLogin.ToString());
        //    var token = dataLogin["jwtToken"].ToString();
        //    var (data, statusCode) = GetArray(UsersApi, token);
        //    Equal("Smed", data.First()["name"]);
        //    var userid = data.Last()["id"];
        //    var userUpdate = new UserForCreateOrUpdateDto();
        //    userUpdate.Name = "Smed3";
        //    userUpdate.Nickname = "Smed3";
        //    var url3 = String.Concat(UsersApi, String.Concat("?id=", (int)userid));
        //    var statusUpdate = PutData(url3, userUpdate, token);
        //    Equal("Ok", statusUpdate.ToString());
        //    var url2 = String.Concat(UsersApi, String.Concat("?id=", (int)userid));
        //    var statusDelete = DeleteData(url2, token);
        //    Equal("Ok", statusDelete.ToString());
        //}


        ////Comments
        //private const string CommentsApi = "https://localhost:5001/api/comments";
        //[Fact]
        //public void TestingComments()
        //{
        //    var newComment = String.Concat(CommentsApi, "/4");
        //    var (getComment, statusCodeGet) = GetObject(newComment);
        //    Equal("OK", statusCodeGet.ToString());
        //    var createComment = new CommentForCreateOrUpdateDto()
        //    {
        //        UserId = 1,
        //        TitleId = "tt11097072",
        //        Comment = "testing",
        //        ParentCommentId = null,
        //        Edited = false
        //    };
        //    var (createdComment, statusCodeCreate) = PostData(CommentsApi, createComment);
        //    Equal("Created", statusCodeCreate.ToString());
        //    var commentId = (int)createdComment["commentId"];
        //    var updateComment = new CommentDto()
        //    {
        //        CommentId = commentId,
        //        CommentTime = DateTime.Now,
        //        UserId = 1,
        //        TitleId = "tt11097072",
        //        Comment = "testing2",
        //        ParentCommentId = null,
        //        Edited = false
        //    };
        //    var url = String.Concat(String.Concat(CommentsApi, "?id="), commentId);
        //    var statusUpdate = PutData(url, updateComment);
        //    Equal("NoContent", statusUpdate.ToString());
        //    var response = DeleteData(url);
        //    Equal("NoContent", response.ToString());
        //}

        ////Titles
        //private const string TitlesApi = "https://localhost:5001/api/titles";
        //[Fact]
        //public void TestingTitles()
        //{
        //    var popularUrl = String.Concat(TitlesApi, String.Concat("/popular", "?type=movie"));
        //    var (data, statusCode) = GetArray(popularUrl);
        //    Equal("The Dark Knight Rises", data.First()["primaryTitle"]);

        //    var popularSeriesUrl = String.Concat(TitlesApi, String.Concat("/popular", "?type=tvSeries"));
        //    var (dataSeries, statusCodeSeries) = GetArray(popularSeriesUrl);
        //    Equal("Young Dylan", dataSeries.First()["primaryTitle"]);

        //    var searchUrl = String.Concat(TitlesApi, "?query=batman");
        //    var (dataSearch, statusCodeSearch) = GetArray(searchUrl);
        //    Equal("Batman Begins", dataSeries.First()["titles"].First()["primaryTitle"]);
        //}

        ////Bookmarks
        //private const string BookmarksApi = "https://localhost:5001/api/bookmarks";

        //[Fact]
        //public void TestingBookmarks()
        //{

        //    var loginUser = new UserForCreateOrUpdateDto
        //    {
        //        Email = "Smedenergod2@gmail.com",
        //        Name = "Smed2",
        //        Password = "Smed2",
        //        Nickname = "Smed2"
        //    };

        //    var url = String.Concat(UsersApi, "/login");
        //    var (dataCreate, statusCodeCreate) = PostData(UsersApi, loginUser);
        //    var (dataLogin, statusLogin) = PostData(url, loginUser);
        //    var token = dataLogin["jwtToken"].ToString();

        //    var (data, statusCode) = GetArray(UsersApi, token);
        //    var userid = data.Last()["userId"];

        //    /*
        //    BookmarkForCreateDto titleBookmark = new BookmarkForCreateDto()
        //    {
        //        UserId = (int)userid,
        //        BookmarkType = BookmarkType.title,
        //        TypeId = "tt0372784"
        //    };
        //    */

        //    BookmarkForCreate titleBookmark = new BookmarkForCreate()
        //    {
        //        UserId = (int)userid,
        //        BookmarkType = "title",
        //        TypeId = "tt0372784"
        //    };


        //    _testOutputHelper.WriteLine(JsonConvert.SerializeObject(titleBookmark));

        //    var (dataTitle, statusTitle) = PostData(BookmarksApi, titleBookmark, token);
        //    Assert.Equal("Created", statusTitle.ToString());

        //    BookmarkForCreate getBookmark = new BookmarkForCreate()
        //    {
        //        UserId = (int)userid,
        //        BookmarkType = "title",
        //        TypeId = null
        //    };

        //    var urlGet = String.Concat(BookmarksApi, JsonConvert.SerializeObject(getBookmark));
        //    _testOutputHelper.WriteLine(urlGet);

        //    var (dataGet, statusGet) = GetObject(urlGet, token);
        //    Assert.Equal("OK", statusGet.ToString());

        //    var deleteUrl = String.Concat(BookmarksApi, JsonConvert.SerializeObject(titleBookmark));

        //    DeleteData(deleteUrl, token);

        //    var (dataGet2, statusGet2) = GetObject(urlGet, token);
        //    Assert.Equal("OK", statusGet2.ToString());


        //    var url3 = String.Concat(UsersApi, "?id=");
        //    url3 = String.Concat(url3, (int)userid);
        //    var statusDelete = DeleteData(url3, token);
        //    Assert.Equal("NoContent", statusDelete.ToString());
        //}


        ////Helpers
        //(JArray, HttpStatusCode) GetArray(string url, string token = "")
        //{
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    var response = client.GetAsync(url).Result;
        //    var data = response.Content.ReadAsStringAsync().Result;
        //    return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        //}

        //(JObject, HttpStatusCode) GetObject(string url, string token = "")
        //{
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    var response = client.GetAsync(url).Result;
        //    var data = response.Content.ReadAsStringAsync().Result;
        //    return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        //}

        //(JObject, HttpStatusCode) PostData(string url, object content, string token = "")
        //{
        //    var client = new HttpClient();
        //    var requestContent = new StringContent(
        //        JsonConvert.SerializeObject(content),
        //        Encoding.UTF8,
        //        "application/json");

        //    requestContent.Headers.Add("Bearer", token);
        //    var response = client.PostAsync(url, requestContent).Result;
        //    var data = response.Content.ReadAsStringAsync().Result;
        //    return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        //}

        //HttpStatusCode DeleteData(string url, string token = "")
        //{
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    var response = client.DeleteAsync(url).Result;
        //    return response.StatusCode;
        //}

        //HttpStatusCode PutData(string url, object content, string token = "")
        //{
        //    var client = new HttpClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //    var response = client.PutAsync(
        //        url,
        //        new StringContent(
        //            JsonConvert.SerializeObject(content),
        //            Encoding.UTF8,
        //            "application/json")).Result;
        //    return response.StatusCode;
        //}

        //internal class CommentForGetDto
        //{
        //    public int UserId;
        //    public string TitleId;
        //}

        //internal class BookmarkForCreate
        //{
        //    public int UserId;
        //    public string BookmarkType;
        //    public string TypeId;
        //}
    }
}
