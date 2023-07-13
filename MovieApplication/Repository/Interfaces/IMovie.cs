using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;
using MovieApplication.Repository.Implementations;

namespace MovieApplication.Repository.Interfaces
{
    public interface IMovie
    {
        bool AddMovies(AddMovie addmovie);
        bool UpdateMovies(UpdateMovie updatemovie);
        bool DeleteMovies(UpdateMovie deletemovie);
        UpdateMovie GetByID(int Id);
        List<MovieModel> GetAllMovies();

    }
}
