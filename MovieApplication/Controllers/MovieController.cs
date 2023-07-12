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
            return View(movie);
        }
    }
}
