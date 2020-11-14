using System;
using Xunit;

namespace WebService.WebServiceTests
{
    public class CastTests
    {

        private const string CastsApi = "https://localhost:5001/api/casts";
        [Fact]
        public void TestingCastsByTitle()
        {
            var titleId = new CommentForGetDto()
            {
                TitleId = "tt0349878",
                UserId = 1
            };
            var urlGet = String.Concat(CastsApi, String.Concat("/", titleId.TitleId));
            var (dataGet, statusGet) = TestHelpers.GetArray(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }


        [Fact]
        public void TestingAllCasts()
        {
            var urlGet = CastsApi;
            var (dataGet, statusGet) = TestHelpers.GetObject(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }


        private const string CastInfoApi = "https://localhost:5001/api/castinfo";
        [Fact]
        public void GetAllCastInfos()
        {
            var urlGet = CastInfoApi;
            var (dataGet, statusGet) = TestHelpers.GetArray(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }

        [Fact]
        public void GetCastInfoByCastId()
        {
            var titleId = new CommentForGetDto()
            {
                TitleId = "tt0349878",
                UserId = 1
            };
            var urlGet = String.Concat(CastInfoApi, String.Concat("/", titleId.TitleId));
            var (dataGet, statusGet) = TestHelpers.GetArray(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }

        private const string CastProfessionApi = "https://localhost:5001/api/professions";
        [Fact]
        public void GetCastProfessionByCastId()
        {
            var urlGet = String.Concat(CastProfessionApi, String.Concat("/", "nm0000083"));
            var (dataGet, statusGet) = TestHelpers.GetArray(urlGet);
            Assert.Equal("OK", statusGet.ToString());
        }


        private const string CastKnownForApi = "https://localhost:5001/api/knownfor";
        [Fact]
        public void GetCastKnownForByCastId()
        {
            var urlGet = String.Concat(CastKnownForApi, String.Concat("/", "nm0000083"));
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
