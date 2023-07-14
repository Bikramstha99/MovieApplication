using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Data;
using MovieApplication.Migrations;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;
using MovieApplication.Repository.Interfaces;

namespace MovieApplication.Repository.Implementations
{
    public class Movie : IMovie
    {
        private readonly MovieDbContext _moviedbcontext;
        

        public Movie(MovieDbContext moviedbcontext)
        {
            _moviedbcontext = moviedbcontext;
            
        }
        public List<MovieModel> GetAllMovies()
        {
            var movie = _moviedbcontext.MovieModels.ToList();
            return movie;
        }

        public bool AddMovies(AddMovie addmovie)
        {
           
                var movie = new MovieModel()
                {
                    Name = addmovie.Name,
                    Genre = addmovie.Genre,
                    Image = addmovie.Image,
                    Director = addmovie.Director,
                    Country = addmovie.Country,

                  
                };
                _moviedbcontext.MovieModels.Add(movie);
                _moviedbcontext.SaveChanges();  
                return true;

         
        }
        public UpdateMovie GetByID(int Id)
        {
            var movie = _moviedbcontext.MovieModels.Find(Id);
            var viewmodel = new UpdateMovie()
            {
                Id = movie.Id,
                Name = movie.Name,
                Genre = movie.Genre,
                Image= movie.Image,
                Director = movie.Director,
                Country=movie.Country,

            };
            return viewmodel;

        }

        public bool UpdateMovies(UpdateMovie updatemovie)
        {
            var movie = _moviedbcontext.MovieModels.Find(updatemovie.Id);
            movie.Id = updatemovie.Id;
            movie.Name = updatemovie.Name;
            movie.Genre = updatemovie.Genre;
            movie.Image = updatemovie.Image;
            movie.Director = updatemovie.Director;
            movie.Country = updatemovie.Country;
           
            _moviedbcontext.SaveChanges();
            return true;
        }
           

        public bool DeleteMovies(UpdateMovie deletemovie)
        {
            var movie = _moviedbcontext.MovieModels.Find(deletemovie.Id);
            _moviedbcontext.MovieModels.Remove(movie);
            _moviedbcontext.SaveChanges();
            return true;
        }
    }
}
