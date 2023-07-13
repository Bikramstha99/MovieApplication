using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;

namespace MovieApplication.Data
{
    public class MovieDbContext : IdentityDbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MovieModel> MovieModels { get; set; }
        public DbSet<MovieApplication.Models.Dto.AddMovie>? AddMovie { get; set; }
        public DbSet<MovieApplication.Models.Dto.UpdateMovie>? UpdateMovie { get; set; }
    }
}
