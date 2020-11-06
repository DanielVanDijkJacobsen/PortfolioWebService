using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataServiceLibrary
{
    public class DataService
    {
        private List<Actor> _actors = new List<Actor>
        {
            new Actor{Id = 0, Primaryname = "John Doe"}
        };

        public IList<Actor> GetActors()
        {
            return _actors;
        }

        public Actor GetActorById(int id)
        {
            return _actors.FirstOrDefault(x => x.Id == id);
        }
    }
}
