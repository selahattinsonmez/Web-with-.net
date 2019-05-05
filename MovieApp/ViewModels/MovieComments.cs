using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.ViewModels
{
    public class MovieComments
    {
        public Movie movie;
        public IEnumerable<Comment> comments;
        public IEnumerable<Category> categories;
    }
}
