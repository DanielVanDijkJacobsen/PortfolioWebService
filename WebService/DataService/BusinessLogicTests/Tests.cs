using System.Linq;
using WebService.DataService.BusinessLogic;
using Xunit;
using static Xunit.Assert;

namespace WebService.DataService.BusinessLogicTests
{
    public class Tests
    {

        public IFrameworkDataService Framework = new FrameworkDataService();
        public ITitlesDataService Movie = new TitleDataService();
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
    }
}
