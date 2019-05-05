using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Actor
    {

        public Actor() {

            MovieActors = new HashSet<MovieActor>();
        }
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }


        public ICollection<MovieActor> MovieActors { get; set; }

    }
}
