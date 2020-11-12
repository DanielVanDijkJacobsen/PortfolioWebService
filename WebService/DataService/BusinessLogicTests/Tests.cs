using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebService.DataService.BusinessLogic;
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
            Equal(1, title.TitleAlias.Count);
        }

        [Fact]
        public void SearchForTitle()
        {
            var title = Movie.SearchForTitle(1, "casino").Result;
            Equal("Joji Feat. Clams Casino: Can't Get Over You", title.First().PrimaryTitle);
            Equal("Joji Feat. Clams Casino: Can't Get Over You", title.First().OriginalTitle);
            Equal("American Casino", title.Last().PrimaryTitle);
            Equal("American Casino", title.Last().OriginalTitle);
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
        private const string UsersApi = "https://localhost:5001/api/users";
        [Fact]
        public void WebServiceGetAllUsers()
        {
            var loginUser = new UserForCreateOrUpdateDto();
            loginUser.Email = "Smedenergod2@gmail.com";
            loginUser.Name = "Smed2";
            loginUser.Password = "Smed2";
            loginUser.Nickname = "Smed2";

            var url = String.Concat(UsersApi, "/login");
            var (dataCreate, statusCodeCreate) = PostData(UsersApi, loginUser);
            Equal("Ok", statusCodeCreate.ToString());
            var (dataLogin, statusLogin) = PostData(url, loginUser);
            Equal("Ok", statusLogin.ToString());
            var token = dataLogin["jwtToken"].ToString();

            var (data, statusCode) = GetArray(UsersApi, token);
            Equal("Smed", data.First()["name"]);
            var userid = data.Last()["id"];
            var userUpdate = new UserForCreateOrUpdateDto();
            userUpdate.Name = "Smed3";
            userUpdate.Nickname = "Smed3";

            var url3 = String.Concat(UsersApi, String.Concat("?id=", (int)userid));
            var statusUpdate = PutData(url3, userUpdate, token);
            Equal("Ok", statusUpdate.ToString());

            var url2 = String.Concat(UsersApi, String.Concat("?id=", (int)userid));
            var statusDelete = DeleteData(url2, token);
            Equal("Ok", statusDelete.ToString());
        }


        //Helpers
        (JArray, HttpStatusCode) GetArray(string url, string token = "")
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) GetObject(string url, string token ="")
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) PostData(string url, object content, string token = "")
        {
            var client = new HttpClient();
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            requestContent.Headers.Add("Bearer", token);
            var response = client.PostAsync(url, requestContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        HttpStatusCode DeleteData(string url, string token = "")
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.DeleteAsync(url).Result;
            return response.StatusCode;
        }

        HttpStatusCode PutData(string url, object content, string token = "")
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = client.PutAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(content),
                    Encoding.UTF8,
                    "application/json")).Result;
            return response.StatusCode;
        }
    }
}
