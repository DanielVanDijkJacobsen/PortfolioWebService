using System;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using WebService.DataService.CustomTypes;
using WebService.DTOs;
using Xunit;
using Xunit.Abstractions;

namespace WebService.WebServiceTests
{
    public class UserTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UserTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        //Users
        private const string UsersApi = "https://localhost:5001/api/users";
        [Fact]
        public void TestingUsers()
        {
            var loginUser = new UserForCreateOrUpdateDto
            {
                Email = "Smedenergod2@gmail.com",
                Name = "Smed2",
                Password = "Smed2",
                Nickname = "Smed2"
            };

            var url = String.Concat(UsersApi, "/login");
            var (dataCreate, statusCodeCreate) = TestHelpers.PostData(UsersApi, loginUser);
            var (dataLogin, statusLogin) = TestHelpers.PostData(url, loginUser);
            var token = dataLogin["jwtToken"].ToString();

            var (data, statusCode) = TestHelpers.GetArray(UsersApi, token);
            Assert.Equal("Smed", data.First()["name"]);
            var userid = data.Last()["userId"];
            var userUpdate = new UserForCreateOrUpdateDto();
            userUpdate.Name = "Smed3";
            userUpdate.Nickname = "Smed3";

            var url3 = String.Concat(UsersApi, "?id=");
            url3 = String.Concat(url3, (int)userid);
            var statusUpdate = TestHelpers.PutData(url3, userUpdate, token);
            Assert.Equal("NoContent", statusUpdate.ToString());
            var statusDelete = TestHelpers.DeleteData(url3, token);
            Assert.Equal("NoContent", statusDelete.ToString());
        }

        //Comments
        private const string CommentsApi = "https://localhost:5001/api/comments";

        [Fact]
        public void TestingComments()
        {
            var loginUser = new UserForCreateOrUpdateDto
            {
                Email = "Smedenergod2@gmail.com",
                Name = "Smed2",
                Password = "Smed2",
                Nickname = "Smed2"
            };

            var urlUser = String.Concat(UsersApi, "/login");
            var (dataCreate, statusCodeUserCreate) = TestHelpers.PostData(UsersApi, loginUser);
            var (dataLogin, statusLogin) = TestHelpers.PostData(urlUser, loginUser);
            var token = dataLogin["jwtToken"].ToString();


            var newComment = String.Concat(CommentsApi, "/4");
            var (getComment, statusCodeGet) = TestHelpers.GetObject(newComment);
            Assert.Equal("OK", statusCodeGet.ToString());

            var (data, statusCode) = TestHelpers.GetArray(UsersApi, token);
            var userid = data.Last()["userId"];

            var createComment = new CommentForCreateOrUpdateDto()
            {
                UserId = (int)userid,
                TitleId = "tt11097072",
                Comment = "testing",
                ParentCommentId = null,
                Edited = false
            };

            var (createdComment, statusCodeCreate) = TestHelpers.PostData(CommentsApi, createComment, token);
            Assert.Equal("Created", statusCodeCreate.ToString());
            var commentId = (int)createdComment["commentId"];

            var updateComment = new CommentDto()
            {
                CommentId = commentId,
                CommentTime = DateTime.Now,
                UserId = (int)userid,
                TitleId = "tt11097072",
                Comment = "testing2",
                ParentCommentId = null,
                Edited = false
            };

            var url = String.Concat(String.Concat(CommentsApi, "/"), commentId);
            var statusUpdate = TestHelpers.PutData(CommentsApi, updateComment, token);

            Assert.Contains("204", JsonConvert.SerializeObject(statusUpdate));

            var response = TestHelpers.DeleteData(url, token);
            Assert.Contains("NoContent", response.ToString());

            var url3 = String.Concat(UsersApi, "?id=");
            url3 = String.Concat(url3, (int)userid);
            var statusDelete = TestHelpers.DeleteData(url3, token);
            Assert.Contains("NoContent", statusDelete.ToString());
        }



        //Bookmarks
        private const string BookmarksApi = "https://localhost:5001/api/bookmarks";

        [Fact]
        public void TestingBookmarks()
        {
            var loginUser = new UserForCreateOrUpdateDto
            {
                Email = "Smedenergod2@gmail.com",
                Name = "Smed2",
                Password = "Smed2",
                Nickname = "Smed2"
            };

            var url = String.Concat(UsersApi, "/login");
            var (dataCreate, statusCodeCreate) = TestHelpers.PostData(UsersApi, loginUser);
            var (dataLogin, statusLogin) = TestHelpers.PostData(url, loginUser);
            var token = dataLogin["jwtToken"].ToString();

            var (data, statusCode) = TestHelpers.GetArray(UsersApi, token);
            var userid = data.Last()["userId"];

            BookmarkForCreate titleBookmark = new BookmarkForCreate()
            {
                UserId = (int)userid,
                BookmarkType = "title",
                TypeId = "tt0372784"
            };


            var (dataTitle, statusTitle) = TestHelpers.PostData(BookmarksApi, titleBookmark, token);
            Assert.Equal("Created", statusTitle.ToString());

            var urlGet = String.Concat(BookmarksApi, String.Concat("/", titleBookmark.UserId));
            Thread.Sleep(3000);
            var (dataGet, statusGet) = TestHelpers.GetObject(urlGet, token);
            Assert.Contains("OK", statusGet.ToString());
            var deleteUrl = String.Concat(BookmarksApi, JsonConvert.SerializeObject(titleBookmark));

            TestHelpers.DeleteData(deleteUrl, token);
            var url3 = String.Concat(UsersApi, "?id=");
            url3 = String.Concat(url3, (int)userid);
            var statusDelete = TestHelpers.DeleteData(url3, token);
            Assert.Equal("NoContent", statusDelete.ToString());
        }

        //SpecialRoles
        private const string RolesApi = "https://localhost:5001/api/roles";
        [Fact]
        public void TestingRoles()
        {
            var loginUser = new UserForCreateOrUpdateDto
            {
                Email = "Smedenergod2@gmail.com",
                Name = "Smed2",
                Password = "Smed2",
                Nickname = "Smed2"
            };

            var url = String.Concat(UsersApi, "/login");
            var (dataCreate, statusCodeCreate) = TestHelpers.PostData(UsersApi, loginUser);
            var (dataLogin, statusLogin) = TestHelpers.PostData(url, loginUser);
            var token = dataLogin["jwtToken"].ToString();

            var (data, statusCode) = TestHelpers.GetArray(UsersApi, token);
            var userid = data.Last()["userId"];

            var role = new SpecialRoleDto()
            {
                UserId = (int)userid,
                RoleType = RoleType.moderator
            };

            var (dataTitle, statusTitle) = TestHelpers.PostData(RolesApi, role, token);
            Assert.Equal("Created", statusTitle.ToString());
            var urlGet = String.Concat(RolesApi, String.Concat("/", (int) userid));

            role.RoleType = RoleType.owner;

            var statusUpdate = TestHelpers.PutData(RolesApi, role, token);

            Assert.Contains("204", JsonConvert.SerializeObject(statusUpdate));


            var response = TestHelpers.DeleteData(urlGet, token);
            Assert.Contains("NoContent", response.ToString());

            var url3 = String.Concat(UsersApi, "?id=");
            url3 = String.Concat(url3, (int)userid);
            var statusDelete = TestHelpers.DeleteData(url3, token);
            Assert.Equal("NoContent", statusDelete.ToString());
        }
    }

    internal class CommentForGetDto
    {
        public int UserId;
        public string TitleId;
    }

    internal class BookmarkForCreate
    {
        public int UserId;
        public string BookmarkType;
        public string TypeId;
    }
}
