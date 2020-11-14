using System;
using System.Linq;
using Xunit;

namespace WebService.WebServiceTests
{
    public class TitleTests
    {
        private const string TitlesApi = "https://localhost:5001/api/titles";
        [Fact]
        public void TestingTitles()
        {
            var popularUrl = String.Concat(TitlesApi, String.Concat("/popular", "?type=movie"));
            var (data, statusCode) = TestHelpers.GetArray(popularUrl);
            Assert.Equal("The Dark Knight Rises", data.First()["primaryTitle"]);

            var popularSeriesUrl = String.Concat(TitlesApi, String.Concat("/popular", "?type=tvSeries"));
            var (dataSeries, statusCodeSeries) = TestHelpers.GetArray(popularSeriesUrl);
            Assert.Equal("Young Dylan", dataSeries.First()["primaryTitle"]);

            var searchUrl = String.Concat(TitlesApi, "?query=batman");
            var (dataSearch, statusCodeSearch) = TestHelpers.GetObject(searchUrl);
            Assert.Equal("Batman Begins", dataSearch["titles"][0]["primaryTitle"]);
        }

        private const string GenresApi = "https://localhost:5001/api/genre";
        [Fact]
        public void TestingGenreByTitle()
        {
            var titleId = new CommentForGetDto()
            {
                TitleId = "tt0349878",
                UserId = 1
            };
            var urlGet = String.Concat(GenresApi, String.Concat("?id=", titleId.TitleId));
            var (dataGet, statusGet) = TestHelpers.GetObject(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }

        [Fact]
        public void TestingAllGenres()
        {
            var urlGet = GenresApi;
            var (dataGet, statusGet) = TestHelpers.GetObject(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }

        private const string FormatsApi = "https://localhost:5001/api/formats";
        [Fact]
        public void TestingFormatByTitle()
        {
            var titleId = new CommentForGetDto()
            {
                TitleId = "tt0349878",
                UserId = 1
            };
            var urlGet = String.Concat(FormatsApi, String.Concat("?id=", titleId.TitleId));
            var (dataGet, statusGet) = TestHelpers.GetObject(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }

        [Fact]
        public void TestingAllFormats()
        {
            var urlGet = FormatsApi;
            var (dataGet, statusGet) = TestHelpers.GetObject(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }


        private const string TitleInfoApi = "https://localhost:5001/api/titleinfo";
        [Fact]
        public void TestingTitleInfo()
        {
            var titleId = new CommentForGetDto()
            {
                TitleId = "tt0349878",
                UserId = 1
            };
            var urlGet = String.Concat(TitleInfoApi, String.Concat("/", titleId.TitleId));
            var (dataGet, statusGet) = TestHelpers.GetArray(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }

        private const string TitleAliasApi = "https://localhost:5001/api/titlealias";
        [Fact]
        public void TestingTitleAlias()
        {
            var titleId = new CommentForGetDto()
            {
                TitleId = "tt0349878",
                UserId = 1
            };
            var urlGet = String.Concat(TitleAliasApi, String.Concat("/", titleId.TitleId));
            var (dataGet, statusGet) = TestHelpers.GetArray(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }
        internal class CommentForGetDto
        {
            public int UserId;
            public string TitleId;
        }

    }
}
