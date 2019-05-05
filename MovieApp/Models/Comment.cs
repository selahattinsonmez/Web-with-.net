using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }


        public Movie Movie { get; set; }

    }
}
