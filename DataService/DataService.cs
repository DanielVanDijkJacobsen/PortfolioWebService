using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataServiceLibrary
{
    public class DataService
    {
        //contains mockup dummy actors.
        private List<Actor> _actors = new List<Actor>
        {
            new Actor{Id = "0", PrimaryName = "John Doe"}
        };

        public IList<Actor> GetActors() //Should return list of actors from DB.
        {
            return _actors;
        }

        public Actor GetActorById(string id) //
        {
            return _actors.FirstOrDefault(x => x.Id == id);
        }
    }
}
