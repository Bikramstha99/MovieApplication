using Microsoft.AspNetCore.Mvc;
using MovieApplication.Data;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;

namespace MovieApplication.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _moviedbcontext;

        public MovieController(MovieDbContext moviedbcontext)
        {
            _moviedbcontext = moviedbcontext;
        }
        [HttpGet]

        public IActionResult Index()
        {
            var movie= _moviedbcontext.MovieModels.ToList();
            return View(movie);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddMovie addmovie)
        {
            var movie = new MovieModel()
            {              
                Name = addmovie.Name,
                Category = addmovie.Category,
            };
            _moviedbcontext.MovieModels.Add(movie);
            _moviedbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult View(int Id)
        {
            {
                var movie= _moviedbcontext.MovieModels.FirstOrDefault(e => e.Id == Id);
                if (movie != null)
                {
                    var viewmodel = new UpdateMovie()
                    {
                        Id = movie.Id,
                        Name = movie.Name,
                        Category = movie.Category,
                      
                    };
                    return View("View", viewmodel);
                }
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult View(UpdateMovie updatemovie)
        {
            var movie =  _moviedbcontext.MovieModels.Find(updatemovie.Id);
            if (movie != null)
            {
                movie.Name = updatemovie.Name;
                movie.Category = updatemovie.Category;
                _moviedbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult Delete(UpdateMovie model)
        {
            var student = _moviedbcontext.MovieModels.Find(model.Id);
            if (student != null)
            {
                _moviedbcontext.MovieModels.Remove(student);
                _moviedbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}  

        
