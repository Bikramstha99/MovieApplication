using Microsoft.EntityFrameworkCore;
using MovieApplication.Models.Domain;

namespace MovieApplication.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MovieModel> MovieModels { get; set; }
    }
}
