using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MovieApplication.Data;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;
using MovieApplication.Repository.Implementations;
using MovieApplication.Repository.Interfaces;

namespace MovieApplication.Controllers
{
    [Authorize (Roles="Admin")]
    public class MovieController : Controller
    {
        private readonly IMovie _IMovie;
        private readonly IWebHostEnvironment _iwebhostenvironment;

        public MovieController(IMovie imovie, IWebHostEnvironment iwebhostenvironment)
        {
            _IMovie = imovie;
            _iwebhostenvironment = iwebhostenvironment;
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
            var image = Request.Form.Files.FirstOrDefault();
            var fileName = Guid.NewGuid().ToString();
            var path = $@"images\";
            var wwwRootPath = _iwebhostenvironment.WebRootPath;
            var uploads = Path.Combine(wwwRootPath, path);
            var extension = Path.GetExtension(image.FileName);
            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                image.CopyTo(fileStreams);
            }
            addmovie.Image = $"\\images\\{fileName}" + extension;
            _IMovie.AddMovies(addmovie);
            
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var movie = _IMovie.GetByID(Id);
            return View( movie);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMovie updatemovie)
        {
            var images = Request.Form.Files.FirstOrDefault();
            var fileName = Guid.NewGuid().ToString();
            var path = $@"updateimages\";
            var wwwRootPath = _iwebhostenvironment.WebRootPath;
            var uploads = Path.Combine(wwwRootPath, path);
            var extension = Path.GetExtension(images.FileName);
            using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
            {
                images.CopyTo(fileStreams);
            }
            updatemovie.Image = $"\\updateimages\\{fileName}" + extension;
            _IMovie.UpdateMovies(updatemovie);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie= _IMovie.GetByID(id);
            return View(movie);

        }
        [HttpPost]
        public IActionResult Delete(UpdateMovie deletemovie)
        {
            _IMovie.DeleteMovies(deletemovie);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie=_IMovie.GetByID(id);
            return View(movie);
        }
       
    }
}     