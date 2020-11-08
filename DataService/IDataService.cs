using System.Collections.Generic;

namespace DataServiceLibrary
{
    public interface IDataService
    {
        IList<Cast> GetCasts();
        Cast GetCast(string id);
        IList<Title> GetTitles();
        Title GetTitle(string id);
    }
}