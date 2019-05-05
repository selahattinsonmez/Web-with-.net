using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieCategory
    {
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        public Movie movie { get; set; }
        public Category category { get; set; }
    }
}
