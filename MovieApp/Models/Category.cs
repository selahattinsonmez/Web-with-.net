using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class Category
    {
        public Category() {

            MovieCategories = new HashSet<MovieCategory>();

        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<MovieCategory> MovieCategories { get; set; }

    }
}
