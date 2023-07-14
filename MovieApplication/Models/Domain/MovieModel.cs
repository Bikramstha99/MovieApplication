using System.ComponentModel.DataAnnotations;

namespace MovieApplication.Models.Domain
{
    public class MovieModel
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string? Country { get; set; }
        public string Image { get; set; }


    }
}
