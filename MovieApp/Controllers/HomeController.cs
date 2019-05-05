using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using MovieApp.ViewModels;

namespace MovieApp.Controllers
{
    public class HomeController : Controller
    {
        MovieAppContext ctx;
        public HomeController(MovieAppContext c)
        {
            ctx = c;
        }
        public IActionResult Index(int id,string search,float rating)
        {
            if (!String.IsNullOrEmpty(search))
            {
                var mv = ctx.Movies.Where(i => i.Title.Contains(search));
                if (mv.Any() == true)
                    return View(mv);
                else
                    ViewData["movie"] = "Oops! The movie you were looking for could not be found!";
                    return View(mv);
            }

            if (id != 0)
            {
                IEnumerable<Movie> mc = ctx.MovieCategories.Where(i => i.CategoryId == id).Select(i => i.movie).ToList();
                if(rating != 0)
                {
                    mc = mc.Where(i => i.Rating >= 7);
                    return View(mc);
                }

                return View(mc);
            }

            if(rating != 0)
            {
                IEnumerable<Movie> movies = ctx.Movies.Where(i => i.Rating >= 7);
                return View(movies);
            }
            
                return View(ctx.Movies);

        }

        public IActionResult MovieView(int id) {
            MovieComments mc = new MovieComments();
            Movie mv = ctx.Movies.FirstOrDefault(i => i.MovieId == id);
            IEnumerable<Comment> cm = ctx.Comments.Where(i => i.MovieId == id);
            IEnumerable<Category> cat = ctx.MovieCategories.Where(i => i.MovieId == id).Select(i => i.category).ToList();
            mc.movie = mv;
            mc.comments = cm;
            mc.categories = cat;

            return View(mc);
        }

        [HttpPost]
        public IActionResult MovieView(string dname, string dsurname, string demail, string comment, int id)
        {
            MovieComments mc = new MovieComments();
            

            Comment cm = new Comment();
            cm.Name = dname;
            cm.Surname = dsurname;
            cm.Email = demail;
            cm.Comments = comment;
            cm.MovieId = id;

            ctx.Comments.Add(cm);
            ctx.SaveChanges();

            mc.comments = ctx.Comments.Where(i => i.MovieId == id);
            mc.movie = ctx.Movies.FirstOrDefault(i => i.MovieId == id);
            mc.categories = ctx.MovieCategories.Where(i => i.MovieId == id).Select(i => i.category).ToList();

            return View(mc);
        }

     
        public ActionResult Admin()
        {

            IEnumerable<Movie> movies = ctx.Movies;

            return View(movies);
        }

        [HttpPost]
        public IActionResult Admin(int id)
        {

            
            Movie m = ctx.Movies.FirstOrDefault(i => i.MovieId == id);
            ctx.Movies.Remove(m);
            ctx.SaveChanges();

            IEnumerable<MovieCategory> mc = ctx.MovieCategories.Where(i => i.MovieId == id);
            ctx.MovieCategories.RemoveRange(mc);
            ctx.SaveChanges();


            return RedirectToAction("Admin");
        }

        public IActionResult AddMovieView()
        {
            IEnumerable<Category> c = ctx.Categories;
            return View(c);
        }

        [HttpPost]
        public IActionResult AddMovieView(string Title,float Rating,int ReleaseYear,string Image,string Description,List<int> catid)
        {
            Movie m = new Movie();
            m.Title = Title;
            m.Rating = Rating;
            m.ReleaseYear = ReleaseYear;
            m.Image = Image;
            m.Description = Description;
            ctx.Movies.Add(m);
            ctx.SaveChanges();

            foreach (var cid in catid)
            {
                MovieCategory mc = new MovieCategory();
                mc.MovieId = m.MovieId;
                mc.CategoryId = cid;
                ctx.MovieCategories.Add(mc);
                ctx.SaveChanges();
            }


            return View("Admin",ctx.Movies);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin user)
        {
            Admin account = (ctx.Admins.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault());
           
            if (account != null)
            {
                HttpContext.Session.SetString("AdminId", account.AdminId.ToString());
                HttpContext.Session.SetString("Username", account.Username);
                return RedirectToAction("Admin");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is wrong.");
            }
            return View();
        }

       

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        //burda bitiyor

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
