using Microsoft.AspNetCore.Mvc;
using MovieApplication.Data;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;
using MovieApplication.Repository.Interfaces;

namespace MovieApplication.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovie _IMovie;

        public MovieController(IMovie imovie)
        {
            _IMovie = imovie;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _IMovie.GetAllMovies();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddMovie addmovie)
        {
            _IMovie.AddMovies(addmovie);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var movie = _IMovie.GetByID(Id);
            return View("view", movie);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMovie updatemovie)
        {
            _IMovie.UpdateMovies(updatemovie);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie= _IMovie.GetByID(id);
            return View("view", movie);

        }
        [HttpPost]
        public IActionResult Delete(UpdateMovie deletemovie)
        {
            _IMovie.UpdateMovies(deletemovie);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie=_IMovie.GetByID(id);
            return View(movie);
        }
        //[HttpPost]
        //public IActionResult 
    }
}     