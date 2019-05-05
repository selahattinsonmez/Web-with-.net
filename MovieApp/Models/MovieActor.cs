using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieActor
    {
    
        public int MovieId { get; set; }   
        public int ActorId { get; set; }

        public Movie movie { get; set; }
        public Actor actor { get; set; }
    }
}
