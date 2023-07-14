using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApplication.Models.Domain;
using MovieApplication.Models.Dto;

namespace MovieApplication.Data
{
    public class MovieDbContext : IdentityDbContext<IdentityUser>
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        public DbSet<MovieModel> MovieModels { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        
    }
}