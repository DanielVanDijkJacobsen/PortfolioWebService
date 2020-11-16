using System.Linq;
using WebService.DataService.BusinessLogic;
using Xunit;
using Xunit.Abstractions;
using static Xunit.Assert;

namespace WebService.DataService.BusinessLogicTests
{
    public class CastsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public IUsersDataService Framework = new UserDataService();
        public ITitlesDataService Movie = new TitleDataService();
        public ICastsDataService Cast = new CastsDataService();

        public CastsTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact]
        public void GetAllCasts()
        {
            var cast = Cast.GetAllCasts().Result;
            True(cast.Count >= 1, "Expected actualCount to be greater than 1.");
        }

        [Fact]
        public void GetAllCastInfo()
        {
            var castInfos = Cast.GetAllCastInfos().Result;
            True(castInfos.Count >= 1, "Expected actualCount to be greater than 1.");
        }

        [Fact]
        public void GetCastProfessionByCastId()
        {
            var castProfessions = Cast.GetCastProfessionByCastId("nm0000001").Result;
            True(castProfessions.Count >= 1, "Expected actualCount to be greater than 1.");
        }
        [Fact]
        public void GetCastKnownForByCastId()
        {
            var castKnownFors = Cast.GetCastKnownForByCastId("nm0000035").Result;
            True(castKnownFors.Count >= 1, "Expected actualCount to be greater than 1.");
        }
        [Fact]
        public void GetCastInfoByCastId()
        {
            var castInfos = Cast.GetCastInfoByCastId("nm0000001").Result.First();
            Equal("Fred Astaire", castInfos.Name);
        }

        [Fact]
        public void GetCastById()
        {
            var castInfos = Cast.GetCastById("tt0052520", 1).Result;
            Equal("actor", castInfos.Category);
        }
        [Fact]
        public void GetCastInfoById()
        {
            var castInfos = Cast.GetCastInfoById("nm0000001").Result;
            Equal("Fred Astaire", castInfos.Name);
        }
        [Fact]
        public void GetCastsByTitleId()
        {
            var casts = Cast.GetCastsByTitleId("tt0125742").Result;
            True(casts.Count >= 1, "Expected actualCount to be greater than 1.");
        }
        [Fact]
        public void GetNameRatingByCastId()
        {
            var castInfos = Cast.GetNameRatingByCastId("nm0000001").Result;
        }
    }
}
