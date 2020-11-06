using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataServiceLibrary
{
    public class DataService
    {
        private List<Cast> _casts = new List<Cast>
        {
            new Cast{Id = "0", PrimaryName = "John Doe"}
        };

        private List<Title> _titles = new List<Title>
        {
            new Title {Id = "0", PrimaryTitle = "Monty Python and the Holy Grail"}
        };

        public IList<Cast> GetCasts()
        {
            return _casts;
        }

        public Cast GetCast(string id)
        {
            return _casts.FirstOrDefault(x => x.Id == id);
        }

        public IList<Title> GetTitles()
        {
            return _titles;
        }

        public Title GetTitle(string id)
        {
            return _titles.FirstOrDefault(x => x.Id == id);
        }
    }
}
