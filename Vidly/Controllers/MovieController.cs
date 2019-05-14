using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Database;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly VidlyDbContext _context;
        public MovieController()
        {
            _context=new VidlyDbContext();
            
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();
            return View(movies);
        }

        public ActionResult New()
        {
            var generes = _context.Genres.ToList();
            var viewmodel = new MovieFormViewModel
            {
                Genres = generes,
                Movie = new Movie()

            };
            return View(viewmodel);
        }

        public ActionResult Edit(int? id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            var viewmodel=new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("New", viewmodel);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
            }
            
            
                _context.SaveChanges();
            
           
            return RedirectToAction("Index", "Movie");

        }
    }
}