using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MovieApp.Models;


namespace MovieApp.Models
{
    public class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
            MovieCategories = new HashSet<MovieCategory>();
            MovieActors = new HashSet<MovieActor>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public float Rating { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


        public ICollection<Comment> Comments { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }


    }
}
