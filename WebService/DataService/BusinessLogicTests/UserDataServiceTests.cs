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
    public class UserDataServiceTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public IUsersDataService Framework = new UserDataService();
        public ITitlesDataService Movie = new TitleDataService();
        public ICastsDataService Cast = new CastsDataService();

        public UserDataServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void CreateUser()
        {
            var user = new Users() {  Age = 23, Name = "Test User", Password = "test", Email = "test@test.com", Nickname = "Test", Salt = new byte[16]};
            var users = Framework.CreateUser(user).Result;
            Equal("Test User", users.Name);
        }
        [Fact]
        public void GetAllUsers()
        {
            var cast = Framework.GetAllUsers().Result;
            True(cast.Count >= 1, "Expected actualCount to be greater than 1.");
        }
        [Fact]
        public void UpdateUser()
        {
            var user = Framework.GetUserByEmail("test@test.com").Result;
            user.Name = "Test User Updated";
            var updatedUser = Framework.UpdateUser(user.UserId, user).Result;
            Equal("Test User Updated", updatedUser.Name);
        }
        [Fact]
        public void DeleteUser()
        {
            var user = Framework.GetUserByEmail("test@test.com").Result;
            var updatedUser = Framework.DeleteUser(user.UserId).Result;
            Equal("Test User Updated", updatedUser.Name);
        }




        [Fact]
        public void GetForCast()
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
